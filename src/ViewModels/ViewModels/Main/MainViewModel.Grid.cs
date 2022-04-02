using System.Threading.Tasks;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Constants;
using Common.Enums;

namespace ViewModels
{
    public partial class MainViewModel
    {
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

        #region HasEmptyCells: bool

        public bool HasEmptyCells
        {
            get => _hasEmptyCells;
            internal set => SetProperty(ref _hasEmptyCells, value);
        }

        private bool _hasEmptyCells;

        #endregion

        #region GridRowCount: int

        public int GridRowCount
        {
            get => _gridRowCount;
            internal set => SetProperty(ref _gridRowCount, value);
        }

        private int _gridRowCount;

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