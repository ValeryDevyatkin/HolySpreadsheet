using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using BAJIEPA.Senticode.Wpf.Collections;
using BAJIEPA.Senticode.Wpf.Interfaces;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        public IObservableRangeCollection<object> GridData { get; } = new ObservableRangeCollection<object>();

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

            Container.Resolve<ISpreadsheetProcessor>().ProcessInput(parameters);
        }

        #endregion
    }
}