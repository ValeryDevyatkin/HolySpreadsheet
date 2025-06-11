using System.Threading.Tasks;
using System.Windows.Input;
using BAJIEPA.Senticode.MVVM;
using Common.Constants;
using Unity;

namespace ViewModels.Main
{
    public partial class MainViewModel : MainViewModelBase
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
        }

        #region QuickProcess command

        public ICommand QuickProcessCommand => _quickProcessCommand ??=
            new AsyncCommand(
                Container,
                ExecuteQuickProcessAsync,
                progressText: CommandProgressTextStrings.QuickProcess);

        private AsyncCommand _quickProcessCommand;

        private async Task ExecuteQuickProcessAsync(object parameter)
        {
            this.ClearAll();
            this.CopyFromClipboard();
            await this.ProcessInputAsync();
            await this.ProcessOutputAsync();
        }

        #endregion

        #region QuickProcessSqlStringInsert command

        public ICommand QuickProcessSqlStringInsertCommand => _quickProcessSqlStringInsertCommand ??=
            new AsyncCommand(
                Container,
                ExecuteQuickProcessSqlStringInsertAsync,
                progressText: CommandProgressTextStrings.QuickProcess);

        private AsyncCommand _quickProcessSqlStringInsertCommand;

        private async Task ExecuteQuickProcessSqlStringInsertAsync(object parameter)
        {
            this.ClearAll();
            this.CopyFromClipboard();
            await this.ProcessInputAsync();
            await this.ProcessOutputToStringInsertAsync();
        }

        #endregion

        #region QuickProcessSqlNumericInsert command

        public ICommand QuickProcessSqlNumericInsertCommand => _quickProcessSqlNumericInsertCommand ??=
            new AsyncCommand(
                Container,
                ExecuteQuickProcessSqlNumericInsertAsync,
                progressText: CommandProgressTextStrings.QuickProcess);

        private AsyncCommand _quickProcessSqlNumericInsertCommand;

        private async Task ExecuteQuickProcessSqlNumericInsertAsync(object parameter)
        {
            this.ClearAll();
            this.CopyFromClipboard();
            await this.ProcessInputAsync();
            await this.ProcessOutputToNumericInsertAsync();
        }

        #endregion

        #region QuickProcessSqlStringIn command

        public ICommand QuickProcessSqlStringInCommand => _quickProcessSqlStringInCommand ??=
            new AsyncCommand(
                Container,
                ExecuteQuickProcessSqlStringInAsync,
                progressText: CommandProgressTextStrings.QuickProcess);

        private AsyncCommand _quickProcessSqlStringInCommand;

        private async Task ExecuteQuickProcessSqlStringInAsync(object parameter)
        {
            this.ClearAll();
            this.CopyFromClipboard();
            await this.ProcessInputAsync();
            await this.ProcessOutputToStringInAsync();
        }

        #endregion

        #region QuickProcessSqlNumericIn command

        public ICommand QuickProcessSqlNumericInCommand => _quickProcessSqlNumericInCommand ??=
            new AsyncCommand(
                Container,
                ExecuteQuickProcessSqlNumericInAsync,
                progressText: CommandProgressTextStrings.QuickProcess);

        private AsyncCommand _quickProcessSqlNumericInCommand;

        private async Task ExecuteQuickProcessSqlNumericInAsync(object parameter)
        {
            this.ClearAll();
            this.CopyFromClipboard();
            await this.ProcessInputAsync();
            await this.ProcessOutputToNumericInAsync();
        }

        #endregion

        #region ClearAll command

        public ICommand ClearAllCommand => _clearAllCommand ??=
            new Command(ExecuteClearAll);

        private Command _clearAllCommand;

        private void ExecuteClearAll(object parameter)
        {
            this.ClearAll();
        }

        #endregion
    }
}