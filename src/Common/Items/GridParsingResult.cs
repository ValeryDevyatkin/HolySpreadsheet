using System.Collections.Generic;

namespace Common.Items
{
    public class GridParsingResult
    {
        public IReadOnlyList<IReadOnlyList<string>> Rows { get; set; }
        public IReadOnlyList<ColumnInfo> ColumnInfo { get; set; }
    }
}