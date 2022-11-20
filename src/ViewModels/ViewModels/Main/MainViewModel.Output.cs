using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Senticode.Wpf.Base;
using BAJIEPA.Tools.Common.Items;
using Common.Constants;
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
            this.ClearOutput();
        }

        #endregion

        #region ProcessOutput command

        public ICommand ProcessOutputCommand => _processOutputCommand ??=
            new AsyncCommand(ExecuteProcessOutputAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.ProcessOutput);

        private AsyncCommand _processOutputCommand;

        private async Task ExecuteProcessOutputAsync(object parameter)
        {
            await this.ProcessOutputAsync();
        }

        #endregion

        #region ProcessOutputToStringInsert command

        public ICommand ProcessOutputToStringInsertCommand => _processOutputToStringInsertCommand ??=
            new AsyncCommand(ExecuteProcessOutputToSqlStringInsertAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.ProcessOutput);

        private AsyncCommand _processOutputToStringInsertCommand;

        private async Task ExecuteProcessOutputToSqlStringInsertAsync(object parameter)
        {
            await this.ProcessOutputToStringInsertAsync();
        }

        #endregion

        #region ProcessOutputToNumericInsert command

        public ICommand ProcessOutputToNumericInsertCommand => _processOutputToNumericInsertCommand ??=
            new AsyncCommand(ExecuteProcessOutputToNumericInsertAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.ProcessOutput);

        private AsyncCommand _processOutputToNumericInsertCommand;

        private async Task ExecuteProcessOutputToNumericInsertAsync(object parameter)
        {
            await this.ProcessOutputToNumericInsertAsync();
        }

        #endregion

        #region ProcessOutputToStringIn command

        public ICommand ProcessOutputToStringInCommand => _processOutputToStringInCommand ??=
            new AsyncCommand(ExecuteProcessOutputToStringInAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.ProcessOutput);

        private AsyncCommand _processOutputToStringInCommand;

        private async Task ExecuteProcessOutputToStringInAsync(object parameter)
        {
            await this.ProcessOutputToStringInAsync();
        }

        #endregion

        #region ProcessOutputToNumericIn command

        public ICommand ProcessOutputToNumericInCommand => _processOutputToNumericInCommand ??=
            new AsyncCommand(ExecuteProcessOutputToNumericInAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.ProcessOutput);

        private AsyncCommand _processOutputToNumericInCommand;

        private async Task ExecuteProcessOutputToNumericInAsync(object parameter)
        {
            await this.ProcessOutputToNumericInAsync();
        }

        #endregion

        #region CopyToClipboard command

        public ICommand CopyToClipboardCommand => _copyToClipboardCommand ??=
            new AsyncCommand(ExecuteCopyToClipboardAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.CopyToClipboard);

        private AsyncCommand _copyToClipboardCommand;

        private async Task ExecuteCopyToClipboardAsync(object parameter)
        {
            await Task.Delay(0);

            Clipboard.SetText(OutputText);
        }

        #endregion

        #region RemoveDuplicates command

        public ICommand RemoveDuplicatesCommand => _removeDuplicatesCommand ??=
            new AsyncCommand(ExecuteRemoveDuplicatesAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.RemoveDuplicates);

        private AsyncCommand _removeDuplicatesCommand;

        private async Task ExecuteRemoveDuplicatesAsync(object parameter)
        {
            SpreadsheetOutputProcessResult result = null;
            await Task.Run(() =>
            {
                result = Container.Resolve<ISpreadsheetProcessor>().RemoveRowDuplicates(OutputText);
            });

            if (result == null)
            {
                throw new ThisShouldNotBeException();
            }

            this.SetOutputProcessResult(result);
        }

        #endregion
    }
}