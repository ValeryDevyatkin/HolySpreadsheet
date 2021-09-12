using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Enums;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        public ParserConfigurationViewModel OutputParserConfiguration =>
            Container.Resolve<ParserConfigurationViewModel>();

        #region OutputTextCase: TextCaseEnum

        public TextCaseEnum OutputTextCase
        {
            get => _outputTextCase;
            set => SetProperty(ref _outputTextCase, value);
        }

        private TextCaseEnum _outputTextCase;

        #endregion

        #region OutputText: string

        public string OutputText
        {
            get => _outputText;
            set => SetProperty(ref _outputText, value);
        }

        private string _outputText;

        #endregion

        #region ClearOutput command

        public ICommand ClearOutputCommand => _clearOutputCommand ??=
                                                  new Command(ExecuteClearOutput);

        private Command _clearOutputCommand;

        private void ExecuteClearOutput(object parameter)
        {
            OutputText = null;
        }

        #endregion

        #region ProcessOutput command

        public ICommand ProcessOutputCommand => _processOutputCommand ??=
                                                    new Command(ExecuteProcessOutput);

        private Command _processOutputCommand;

        private void ExecuteProcessOutput(object parameter)
        {
            var parameters = new SpreadsheetOutputProcessParameters
            {
                CustomDelimiter = OutputParserConfiguration.CustomDelimiter,
                Delimiter = OutputParserConfiguration.Delimiter,
                RowLeft = OutputParserConfiguration.RowLeft,
                RowRight = OutputParserConfiguration.RowRight,
                WordLeft = OutputParserConfiguration.WordLeft,
                WordRight = OutputParserConfiguration.WordRight,
                TextCase = OutputTextCase
            };

            OutputText = Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(parameters);
        }

        #endregion

        #region ProcessOutputToSql command

        public ICommand ProcessOutputToSqlCommand => _processOutputToSqlCommand ??=
                                                         new Command(ExecuteProcessOutputToSql);

        private Command _processOutputToSqlCommand;

        private void ExecuteProcessOutputToSql(object parameter)
        {
            var parameters = new SpreadsheetOutputProcessParameters
            {
                Delimiter = DelimiterEnum.Comma,
                RowLeft = "(",
                RowRight = "),",
                WordLeft = "\"",
                WordRight = "\"",
                TextCase = OutputTextCase
            };

            OutputText = Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(parameters);
        }

        #endregion

        #region CopyToClipboard command

        public ICommand CopyToClipboardCommand => _copyToClipboardCommand ??=
                                                      new Command(ExecuteCopyToClipboard);

        private Command _copyToClipboardCommand;

        private void ExecuteCopyToClipboard(object parameter)
        {
            Clipboard.SetText(OutputText);
        }

        #endregion

        #region CopyToFile command

        public ICommand CopyToFileCommand => _copyToFileCommand ??=
                                                 new AsyncCommand(ExecuteCopyToFile);

        private AsyncCommand _copyToFileCommand;

        private async Task ExecuteCopyToFile(object parameter)
        {
            await Container.Resolve<IFileDialogService>().SaveToFileAsync(OutputText);
        }

        #endregion
    }
}