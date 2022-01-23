using BAJIEPA.Senticode.Wpf.Base;
using Common.Enums;
using Unity;

namespace ViewModels
{
    public class ParserOutputConfigurationViewModel : ViewModelBase
    {
        public ParserOutputConfigurationViewModel(IUnityContainer container) : base(container)
        {
        }

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

        #region RowWrapper: RowWrapperEnum

        public RowWrapperEnum RowWrapper
        {
            get => _rowWrapper;
            set => SetProperty(ref _rowWrapper, value);
        }

        private RowWrapperEnum _rowWrapper;

        #endregion

        #region CellWrapper: CellWrapperEnum

        public CellWrapperEnum CellWrapper
        {
            get => _cellWrapper;
            set => SetProperty(ref _cellWrapper, value);
        }

        private CellWrapperEnum _cellWrapper;

        #endregion

        #region RowLeft: string

        public string RowLeft
        {
            get => _rowLeft;
            set => SetProperty(ref _rowLeft, value);
        }

        private string _rowLeft;

        #endregion

        #region RowRight: string

        public string RowRight
        {
            get => _rowRight;
            set => SetProperty(ref _rowRight, value);
        }

        private string _rowRight;

        #endregion

        #region WordLeft: string

        public string WordLeft
        {
            get => _wordLeft;
            set => SetProperty(ref _wordLeft, value);
        }

        private string _wordLeft;

        #endregion

        #region WordRight: string

        public string WordRight
        {
            get => _wordRight;
            set => SetProperty(ref _wordRight, value);
        }

        private string _wordRight;

        #endregion
    }
}