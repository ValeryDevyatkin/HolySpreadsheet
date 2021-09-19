using Common.Enums;

namespace Common.Items
{
    public partial class SpreadsheetOutputProcessParameters
    {
        public TextCaseEnum TextCase { get; set; }
        public DelimiterEnum Delimiter { get; set; }
        public string CustomDelimiter { get; set; }
        public string RowLeft { get; set; }
        public string RowRight { get; set; }
        public string WordLeft { get; set; }
        public string WordRight { get; set; }
    }

    public partial class SpreadsheetOutputProcessParameters
    {
        public static SpreadsheetOutputProcessParameters QuickSqlStringInsertPreset =>
            new SpreadsheetOutputProcessParameters
            {
                Delimiter = DelimiterEnum.Comma,
                RowLeft = "(",
                RowRight = "),",
                WordLeft = "'",
                WordRight = "'"
            };
    }
}