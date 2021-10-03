using System;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Interfaces;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        private readonly Lazy<ParserConfigurationViewModel> _inputParserConfiguration =
            new Lazy<ParserConfigurationViewModel>(
                () => ServiceLocator.Container.Resolve<ParserConfigurationViewModel>());

        public ParserConfigurationViewModel InputParserConfiguration => _inputParserConfiguration.Value;

        #region HasEmptyCells: bool

        public bool HasEmptyCells
        {
            get => _hasEmptyCells;
            set => SetProperty(ref _hasEmptyCells, value);
        }

        private bool _hasEmptyCells;

        #endregion

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
            var parameters = GetInputProcessParameters();
            var spreadsheet = Container.Resolve<ISpreadsheetProcessor>().ProcessInput(InputText, parameters);
            HasEmptyCells = spreadsheet.HasEmptyCells;
            Container.Resolve<IDataGridService>().PopulateRows(spreadsheet);
        }

        #endregion
    }
}