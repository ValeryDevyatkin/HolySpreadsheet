using BAJIEPA.Senticode.Wpf.Base;
using Common.Enums;
using Unity;

namespace ViewModels.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() : base(null)
        {
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            InputDelimiter = DelimiterEnum.Comma;
        }

        #region InputDelimiter: DelimiterEnum

        public DelimiterEnum InputDelimiter
        {
            get => _inputDelimiter;
            set => SetProperty(ref _inputDelimiter, value);
        }

        private DelimiterEnum _inputDelimiter;

        #endregion

        #region OutputDelimiter: DelimiterEnum

        public DelimiterEnum OutputDelimiter
        {
            get => _outputDelimiter;
            set => SetProperty(ref _outputDelimiter, value);
        }

        private DelimiterEnum _outputDelimiter;

        #endregion
    }
}