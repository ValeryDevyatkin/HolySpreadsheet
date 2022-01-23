using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Enums;
using Common.Interfaces;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        #region Delimiter: DelimiterEnum

        public DelimiterEnum Delimiter
        {
            get => _delimiter;
            set => SetProperty(ref _delimiter, value);
        }

        private DelimiterEnum _delimiter;

        #endregion

        #region CustomDelimiter: string

        public string CustomDelimiter
        {
            get => _customDelimiter;
            set => SetProperty(ref _customDelimiter, value);
        }

        private string _customDelimiter;

        #endregion

        #region HasEmptyCells: bool

        public bool HasEmptyCells
        {
            get => _hasEmptyCells;
            private set => SetProperty(ref _hasEmptyCells, value);
        }

        private bool _hasEmptyCells;

        #endregion

        #region GridRowCount: int

        public int GridRowCount
        {
            get => _gridRowCount;
            private set => SetProperty(ref _gridRowCount, value);
        }

        private int _gridRowCount;

        #endregion

        #region ProcessInput command

        public ICommand ProcessInputCommand => _processInputCommand ??=
                                                   new Command(ExecuteProcessInput);

        private Command _processInputCommand;

        private void ExecuteProcessInput(object parameter)
        {
            if (string.IsNullOrWhiteSpace(InputText))
            {
                return;
            }

            var parameters = this.GetInputProcessParameters();
            var spreadsheet = Container.Resolve<ISpreadsheetProcessor>().ProcessInput(InputText, parameters);
            HasEmptyCells = spreadsheet.HasEmptyCells;
            GridRowCount = spreadsheet.RowCount;
            Container.Resolve<IDataGridService>().PopulateRows(spreadsheet);
        }

        #endregion

        #region ClearGrid command

        public ICommand ClearGridCommand => _clearGridCommand ??=
                                                new Command(ExecuteClearGrid);

        private Command _clearGridCommand;

        private void ExecuteClearGrid(object parameter)
        {
            HasEmptyCells = false;
            GridRowCount = 0;
            Container.Resolve<IDataGridService>().Clear();
        }

        #endregion
    }
}