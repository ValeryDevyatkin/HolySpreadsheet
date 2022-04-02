using System.Threading.Tasks;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Constants;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
        }

        #region IsPreLoaderVisible: bool

        public bool IsPreLoaderVisible
        {
            get => _isPreLoaderVisible;
            set => SetProperty(ref _isPreLoaderVisible, value);
        }

        private bool _isPreLoaderVisible;

        #endregion

        #region ProgressText: string

        public string ProgressText
        {
            get => _progressText;
            set => SetProperty(ref _progressText, value);
        }

        private string _progressText;

        #endregion

        #region QuickProcess command

        public ICommand QuickProcessCommand => _quickProcessCommand ??=
            new AsyncCommand(ExecuteQuickProcessAsync, shouldBlockUi: true,
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
            new AsyncCommand(ExecuteQuickProcessSqlStringInsertAsync, shouldBlockUi: true,
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
            new AsyncCommand(ExecuteQuickProcessSqlNumericInsertAsync, shouldBlockUi: true,
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
            new AsyncCommand(ExecuteQuickProcessSqlStringInAsync, shouldBlockUi: true,
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
            new AsyncCommand(ExecuteQuickProcessSqlNumericInAsync, shouldBlockUi: true,
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