using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Interfaces;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel
    {
        public ParserConfigurationViewModel InputParserConfiguration =>
            Container.Resolve<ParserConfigurationViewModel>();

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
            InputText = Clipboard.GetText();
        }

        #endregion

        #region CopyFromFile command

        public ICommand CopyFromFileCommand => _copyFromFileCommand ??=
                                                   new AsyncCommand(ExecuteCopyFromFileAsync);

        private AsyncCommand _copyFromFileCommand;

        private async Task ExecuteCopyFromFileAsync(object parameter)
        {
            InputText = await Container.Resolve<IFileDialogService>().ReadFromFileAsync();
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