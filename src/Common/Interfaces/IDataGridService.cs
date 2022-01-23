using System.Collections.Generic;
using Common.Items;

namespace Common.Interfaces
{
    public interface IDataGridService
    {
        void PopulateRows(SpreadsheetInputProcessResult spreadsheet);
        IReadOnlyList<IEnumerable<string>> GetRows();
        void Clear();
    }
}