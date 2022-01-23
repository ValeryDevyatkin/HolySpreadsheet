using System;
using System.Windows;
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
        private readonly Lazy<ParserOutputConfigurationViewModel> _outputParserConfigurationLazy =
            new(() => ServiceLocator.Container.Resolve<ParserOutputConfigurationViewModel>());

        public ParserOutputConfigurationViewModel OutputParserConfiguration => _outputParserConfigurationLazy.Value;

        #region OutputText: string

        public string OutputText
        {
            get => _outputText;
            set => SetProperty(ref _outputText, value);
        }

        private string _outputText;

        #endregion

        #region OutputRowCount: int

        public int OutputRowCount
        {
            get => _outputRowCount;
            set => SetProperty(ref _outputRowCount, value);
        }

        private int _outputRowCount;

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
            if (GridRowCount < 1)
            {
                return;
            }

            var parameters = this.GetOutputProcessParameters();
            var rows = Container.Resolve<IDataGridService>().GetRows();
            this.SetOutputProcessResult(Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters));
        }

        #endregion

        #region ProcessOutputToStringInsert command

        public ICommand ProcessOutputToStringInsertCommand => _processOutputToStringInsertCommand ??=
                                                                  new Command(ExecuteProcessOutputToSqlStringInsert);

        private Command _processOutputToStringInsertCommand;

        private void ExecuteProcessOutputToSqlStringInsert(object parameter)
        {
            if (GridRowCount < 1)
            {
                return;
            }

            var parameters = SpreadsheetOutputProcessParameters.QuickSqlStringInsertPreset;
            var rows = Container.Resolve<IDataGridService>().GetRows();
            this.SetOutputProcessResult(Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters));
        }

        #endregion

        #region ProcessOutputToNumericInsert command

        public ICommand ProcessOutputToNumericInsertCommand => _processOutputToNumericInsertCommand ??=
                                                                   new Command(ExecuteProcessOutputToNumericInsert);

        private Command _processOutputToNumericInsertCommand;

        private void ExecuteProcessOutputToNumericInsert(object parameter)
        {
            if (GridRowCount < 1)
            {
                return;
            }

            var parameters = SpreadsheetOutputProcessParameters.QuickSqlNumericInsertPreset;
            var rows = Container.Resolve<IDataGridService>().GetRows();
            this.SetOutputProcessResult(Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters));
        }

        #endregion

        #region ProcessOutputToStringIn command

        public ICommand ProcessOutputToStringInCommand => _processOutputToStringInCommand ??=
                                                              new Command(ExecuteProcessOutputToStringIn);

        private Command _processOutputToStringInCommand;

        private void ExecuteProcessOutputToStringIn(object parameter)
        {
            if (GridRowCount < 1)
            {
                return;
            }

            var parameters = SpreadsheetOutputProcessParameters.QuickSqlStringInPreset;
            var rows = Container.Resolve<IDataGridService>().GetRows();
            this.SetOutputProcessResult(Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters));
        }

        #endregion

        #region ProcessOutputToNumericIn command

        public ICommand ProcessOutputToNumericInCommand => _processOutputToNumericInCommand ??=
                                                               new Command(ExecuteProcessOutputToNumericIn);

        private Command _processOutputToNumericInCommand;

        private void ExecuteProcessOutputToNumericIn(object parameter)
        {
            if (GridRowCount < 1)
            {
                return;
            }

            var parameters = SpreadsheetOutputProcessParameters.QuickSqlNumericInPreset;
            var rows = Container.Resolve<IDataGridService>().GetRows();
            this.SetOutputProcessResult(Container.Resolve<ISpreadsheetProcessor>().ProcessOutput(rows, parameters));
        }

        #endregion

        #region CopyToClipboard command

        public ICommand CopyToClipboardCommand => _copyToClipboardCommand ??=
                                                      new Command(ExecuteCopyToClipboard);

        private Command _copyToClipboardCommand;

        private void ExecuteCopyToClipboard(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(OutputText))
            {
                Clipboard.SetText(OutputText);
            }
        }

        #endregion

        #region RemoveDuplicates command

        public ICommand RemoveDuplicatesCommand => _removeDuplicatesCommand ??=
                                                       new Command(ExecuteRemoveDuplicates);

        private Command _removeDuplicatesCommand;

        private void ExecuteRemoveDuplicates(object parameter)
        {
            this.SetOutputProcessResult(Container.Resolve<ISpreadsheetProcessor>().RemoveRowDuplicates(OutputText));
        }

        #endregion
    }
}