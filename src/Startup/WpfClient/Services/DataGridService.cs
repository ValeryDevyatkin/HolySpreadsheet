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

        public void PopulateRows(SpreadsheetProcessResult spreadsheet)
        {
            if (spreadsheet == null)
            {
                throw new ArgumentNullException(nameof(spreadsheet));
            }

            var dataGrid = _container.Resolve<GridRegion>().DataGrid;
            dataGrid.Items.Clear();
            dataGrid.Columns.Clear();

            for (var i = 0; i < spreadsheet.ColumnCount; i++)
            {
                var columnNumber = i.ToString();

                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = columnNumber,
                    Binding = new Binding($"[{columnNumber}]") {Mode = BindingMode.OneTime},
                    IsReadOnly = true
                });
            }

            foreach (var cells in spreadsheet.Rows)
            {
                var words = new string[spreadsheet.ColumnCount];
                var enumerator = cells.GetEnumerator();

                for (var i = 0; i < spreadsheet.ColumnCount; i++)
                {
                    words[i] = enumerator.MoveNext() ? enumerator.Current : null;
                }

                dataGrid.Items.Add(words);
            }
        }

        public IEnumerable<IEnumerable<string>> GetRows()
        {
            var dataGrid = _container.Resolve<GridRegion>().DataGrid;

            foreach (var item in dataGrid.Items)
            {
                yield return (IEnumerable<string>) item;
            }
        }
    }
}