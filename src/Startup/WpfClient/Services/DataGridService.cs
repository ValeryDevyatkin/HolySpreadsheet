using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using Common.Interfaces;
using Common.Items;
using Unity;
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

                dataGrid.Columns.Add(new DataGridTextColumn
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

        public IReadOnlyList<IEnumerable<string>> GetRows()
        {
            var dataGrid = _container.Resolve<GridRegion>().DataGrid;
            var result = new List<IEnumerable<string>>();

            foreach (var item in dataGrid.Items)
            {
                result.Add((IEnumerable<string>)item);
            }

            return result;
        }
    }
}