using Common.Items;

namespace Common.Interfaces
{
    public interface IDataGridService
    {
        void PopulateRows(SpreadsheetInputProcessResult spreadsheet);
        GridParsingResult GetRows();
        void Clear();
        public void DeactivateAllColumns();
        public void ActivateAllColumns();
    }
}