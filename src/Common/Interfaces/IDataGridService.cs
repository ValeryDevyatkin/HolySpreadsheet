using System.Collections.Generic;
using Common.Items;

namespace Common.Interfaces
{
    public interface IDataGridService
    {
        void PopulateRows(SpreadsheetProcessResult spreadsheet);
        IEnumerable<IEnumerable<string>> GetRows();
        void Clear();
    }
}