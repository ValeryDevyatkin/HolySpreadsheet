using System.Collections.Generic;

namespace Common.Items
{
    public class SpreadsheetProcessResult
    {
        public SpreadsheetProcessResult(IEnumerable<IEnumerable<string>> rows,
                                        int rowCount,
                                        int columnCount,
                                        bool hasEmptyCells)
        {
            Rows = rows;
            RowCount = rowCount;
            ColumnCount = columnCount;
            HasEmptyCells = hasEmptyCells;
        }

        public bool HasEmptyCells { get; }
        public int RowCount { get; }
        public int ColumnCount { get; }
        public IEnumerable<IEnumerable<string>> Rows { get; }
    }
}