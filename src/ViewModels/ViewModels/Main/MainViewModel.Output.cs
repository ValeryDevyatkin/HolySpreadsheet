using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Enums;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        private readonly Lazy<ParserConfigurationViewModel> _outputParserConfigurationLazy =
            new Lazy<ParserConfigurationViewModel>(
                () => ServiceLocator.Container.Resolve<ParserConfigurationViewModel>());

        public ParserConfigurationViewModel OutputParserConfiguration => _outputParserConfigurationLazy.Value;

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
            var parameters = GetOutputProcessParameters();
            var rows = Container.Resolve<IDataGridService>().GetRows();
            OutputText = Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters);
        }

        #endregion

        #region ProcessOutputToSqlStringInsert command

        public ICommand ProcessOutputToSqlStringInsertCommand => _processOutputToSqlStringInsertCommand ??=
                                                                     new Command(ExecuteProcessOutputToSqlStringInsert);

        private Command _processOutputToSqlStringInsertCommand;

        private void ExecuteProcessOutputToSqlStringInsert(object parameter)
        {
            var parameters = SpreadsheetOutputProcessParameters.QuickSqlStringInsertPreset;
            parameters.TextCase = OutputTextCase;
            var rows = Container.Resolve<IDataGridService>().GetRows();
            OutputText = Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters);
        }

        #endregion

        #region ProcessOutputToNumericInsert command

        public ICommand ProcessOutputToNumericInsertCommand => _processOutputToNumericInsertCommand ??=
                                                                   new Command(ExecuteProcessOutputToNumericInsert);

        private Command _processOutputToNumericInsertCommand;

        private void ExecuteProcessOutputToNumericInsert(object parameter)
        {
            var parameters = SpreadsheetOutputProcessParameters.QuickSqlNumericInsertPreset;
            parameters.TextCase = OutputTextCase;
            var rows = Container.Resolve<IDataGridService>().GetRows();
            OutputText = Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters);
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
                                                 new AsyncCommand(ExecuteCopyToFileAsync);

        private AsyncCommand _copyToFileCommand;

        private async Task ExecuteCopyToFileAsync(object parameter)
        {
            await Container.Resolve<IFileDialogService>().SaveToFileAsync(OutputText);
        }

        #endregion
    }
}