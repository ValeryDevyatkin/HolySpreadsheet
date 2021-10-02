using System;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        private readonly Lazy<ParserConfigurationViewModel> _inputParserConfiguration =
            new Lazy<ParserConfigurationViewModel>(
                () => ServiceLocator.Container.Resolve<ParserConfigurationViewModel>());

        public ParserConfigurationViewModel InputParserConfiguration => _inputParserConfiguration.Value;

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
            var parameters = new SpreadsheetInputProcessParameters
            {
                CustomDelimiter = InputParserConfiguration.CustomDelimiter,
                Delimiter = InputParserConfiguration.Delimiter,
                RowLeft = InputParserConfiguration.RowLeft,
                RowRight = InputParserConfiguration.RowRight,
                WordLeft = InputParserConfiguration.WordLeft,
                WordRight = InputParserConfiguration.WordRight
            };

            var rows = Container.Resolve<ISpreadsheetProcessor>().ProcessInput(InputText, parameters);
            Container.Resolve<IDataGridService>().PopulateRows(rows);
        }

        #endregion
    }
}