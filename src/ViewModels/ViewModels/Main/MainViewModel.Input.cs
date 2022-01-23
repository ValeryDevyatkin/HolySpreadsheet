using System.Windows;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;

namespace ViewModels
{
    public partial class MainViewModel
    {
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
                                                        new Command(ExecuteCopyFromClipboard);

        private Command _copyFromClipboardCommand;

        private void ExecuteCopyFromClipboard(object parameter)
        {
            var clipboardText = Clipboard.GetText();

            if (!string.IsNullOrWhiteSpace(clipboardText))
            {
                InputText = clipboardText;
            }
        }

        #endregion

        #region ClearInput command

        public ICommand ClearInputCommand => _clearInputCommand ??=
                                                 new Command(ExecuteClearInput);

        private Command _clearInputCommand;

        private void ExecuteClearInput(object parameter)
        {
            InputText = null;
        }

        #endregion
    }
}