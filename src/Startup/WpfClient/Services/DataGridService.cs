using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Common.Interfaces;
using Common.Items;
using Unity;
using WpfClient.Views.Controls;
using WpfClient.Views.Regions;

namespace WpfClient.Services
{
    internal class DataGridService : IDataGridService
    {
        private readonly IUnityContainer _container;

        public DataGridService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public void PopulateRows(SpreadsheetInputProcessResult spreadsheet)
        {
            if (spreadsheet == null)
            {
                throw new ArgumentNullException(nameof(spreadsheet));
            }

            Clear();
            var dataGrid = _container.Resolve<GridRegion>().DataGrid;

            for (var i = 0; i < spreadsheet.ColumnCount; i++)
            {
                var columnNumber = (i + 1).ToString();

                dataGrid.Columns.Add(new CustomDataGridTextColumn
                {
                    Header = columnNumber,
                    Binding = new Binding($"[{i}]") { Mode = BindingMode.OneTime },
                    IsReadOnly = true
                });
            }

            foreach (var cells in spreadsheet.Rows)
            {
                var words = new string[spreadsheet.ColumnCount];
                using var enumerator = cells.GetEnumerator();

                for (var i = 0; i < spreadsheet.ColumnCount; i++)
                {
                    words[i] = enumerator.MoveNext() ? enumerator.Current : null;
                }

                dataGrid.Items.Add(words);
            }
        }

        public void Clear()
        {
            var dataGrid = _container.Resolve<GridRegion>().DataGrid;
            dataGrid.Items.Clear();
            dataGrid.Columns.Clear();
        }

        public GridParsingResult GetRows()
        {
            var dataGrid = _container.Resolve<GridRegion>().DataGrid;
            var rows = new List<List<string>>();

            var activeOrderedColumns = dataGrid.Columns
                                               .OfType<CustomDataGridTextColumn>()
                                               .OrderBy(x => x.DisplayIndex)
                                               .Where(x => !x.IsDeactivated)
                                               .Select(x => new ColumnInfo
                                                {
                                                    Index = int.Parse((string)x.Header) - 1,
                                                    IsFormattingDisabled = x.IsFormattingDeactivated
                                                })
                                               .ToArray();

            foreach (var item in dataGrid.Items)
            {
                var sourceItems = (string[])item;
                var orderedItems = new List<string>();

                for (var i = 0; i < activeOrderedColumns.Length; i++)
                {
                    orderedItems.Add(sourceItems[activeOrderedColumns[i].Index]);
                }

                rows.Add(orderedItems);
            }

            return new GridParsingResult
            {
                Rows = rows,
                ColumnInfo = activeOrderedColumns
            };
        }
    }
}