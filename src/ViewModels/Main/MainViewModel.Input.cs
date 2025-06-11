using System.Threading.Tasks;
using System.Windows.Input;
using BAJIEPA.Senticode.MVVM;
using Common.Constants;

namespace ViewModels.Main
{
    public partial class MainViewModel
    {
        #region IsEditModeOn: bool

        public bool IsEditModeOn
        {
            get => _isEditModeOn;
            set => SetProperty(ref _isEditModeOn, value);
        }

        private bool _isEditModeOn;

        #endregion

        #region InputText: string

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        private string _inputText;

        #endregion

        #region CopyFromClipboard command

        public ICommand CopyFromClipboardCommand => _copyFromClipboardCommand ??=
            new AsyncCommand(
                Container,
                ExecuteCopyFromClipboardAsync,
                progressText: CommandProgressTextStrings.CopyFromClipboard);

        private AsyncCommand _copyFromClipboardCommand;

        private Task ExecuteCopyFromClipboardAsync(object parameter)
        {
            this.CopyFromClipboard();

            return Task.CompletedTask;
        }

        #endregion

        #region ClearInput command

        public ICommand ClearInputCommand => _clearInputCommand ??=
            new Command(ExecuteClearInput);

        private Command _clearInputCommand;

        private void ExecuteClearInput(object parameter)
        {
            this.ClearInput();
        }

        #endregion

        #region SwitchEditMode command

        public ICommand SwitchEditModeCommand => _switchEditModeCommand ??=
            new Command(ExecuteSwitchEditMode);

        private Command _switchEditModeCommand;

        private void ExecuteSwitchEditMode(object parameter)
        {
            IsEditModeOn = !IsEditModeOn;
        }

        #endregion
    }
}