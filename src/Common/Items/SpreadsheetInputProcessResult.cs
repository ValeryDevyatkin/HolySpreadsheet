using System.Collections.Generic;

namespace Common.Items
{
    public class SpreadsheetInputProcessResult
    {
        public SpreadsheetInputProcessResult(IEnumerable<IEnumerable<string>> rows,
                                        int rowCount,
                                        int columnCount)
        {
            Rows = rows;
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        public int RowCount { get; }
        public int ColumnCount { get; }
        public IEnumerable<IEnumerable<string>> Rows { get; }
    }
}