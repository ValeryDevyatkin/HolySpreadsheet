using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        #region GridRowCount: int

        public int GridRowCount
        {
            get => _gridRowCount;
            set => SetProperty(ref _gridRowCount, value);
        }

        private int _gridRowCount;

        #endregion

        #region ProcessInput command

        public ICommand ProcessInputCommand => _processInputCommand ??=
                                                   new Command(ExecuteProcessInput);

        private Command _processInputCommand;

        private void ExecuteProcessInput(object parameter)
        {
            var parameters = new SpreadsheetInputParseParameters
            {
                CustomDelimiter = InputParserConfiguration.CustomDelimiter,
                Delimiter = InputParserConfiguration.Delimiter,
                RowLeft = InputParserConfiguration.RowLeft,
                RowRight = InputParserConfiguration.RowRight,
                WordLeft = InputParserConfiguration.WordLeft,
                WordRight = InputParserConfiguration.WordRight
            };

            var rows = Container.Resolve<ISpreadsheetProcessor>().ProcessInput(InputText, parameters);
            Container.Resolve<IDataGridService>().FillGrid(rows);
        }

        #endregion
    }
}