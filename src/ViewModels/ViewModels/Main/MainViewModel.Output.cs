using Common.Enums;
using Unity;

namespace ViewModels.ViewModels
{
    public partial class MainViewModel
    {
        public ParserConfigurationViewModel OutputParserConfiguration =>
            Container.Resolve<ParserConfigurationViewModel>();

        #region OutputTextCase: TextCaseEnum

        public TextCaseEnum OutputTextCase
        {
            get => _outputTextCase;
            set => SetProperty(ref _outputTextCase, value);
        }

        private TextCaseEnum _outputTextCase;

        #endregion

        #region OutputText: string

        public string OutputText
        {
            get => _outputText;
            set => SetProperty(ref _outputText, value);
        }

        private string _outputText;

        #endregion
    }
}