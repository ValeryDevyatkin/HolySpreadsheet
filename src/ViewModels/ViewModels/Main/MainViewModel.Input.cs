using Unity;

namespace ViewModels.ViewModels
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
    }
}