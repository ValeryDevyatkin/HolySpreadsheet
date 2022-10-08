using System.Threading.Tasks;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Constants;
using Common.Enums;

namespace ViewModels
{
    public partial class MainViewModel
    {
        #region ShouldPullInLine: bool

        public bool ShouldPullInLine
        {
            get => _shouldPullInLine;
            set => SetProperty(ref _shouldPullInLine, value);
        }

        private bool _shouldPullInLine;

        #endregion

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

        #region GridRowCount: int

        public int GridRowCount
        {
            get => _gridRowCount;
            internal set => SetProperty(ref _gridRowCount, value);
        }

        private int _gridRowCount;

        #endregion

        #region GridColumnCount: int

        public int GridColumnCount
        {
            get => _gridColumnCount;
            set => SetProperty(ref _gridColumnCount, value);
        }

        private int _gridColumnCount;

        #endregion

        #region ProcessInput command

        public ICommand ProcessInputCommand => _processInputCommand ??=
            new AsyncCommand(ExecuteProcessInputAsync, shouldBlockUi: true,
                progressText: CommandProgressTextStrings.ProcessInput);

        private AsyncCommand _processInputCommand;

        private async Task ExecuteProcessInputAsync(object parameter)
        {
            await this.ProcessInputAsync();
        }

        #endregion

        #region ClearGrid command

        public ICommand ClearGridCommand => _clearGridCommand ??=
            new Command(ExecuteClearGrid);

        private Command _clearGridCommand;

        private void ExecuteClearGrid(object parameter)
        {
            this.ClearGrid();
        }

        #endregion
    }
}