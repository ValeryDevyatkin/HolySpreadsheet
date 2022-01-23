using Common.Enums;

namespace Common.Items
{
    public partial class SpreadsheetOutputProcessParameters
    {
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
            new()
            {
                Delimiter = DelimiterEnum.Comma,
                RowLeft = "(",
                RowRight = "),",
                WordLeft = "'",
                WordRight = "'"
            };

        public static SpreadsheetOutputProcessParameters QuickSqlNumericInsertPreset =>
            new()
            {
                Delimiter = DelimiterEnum.Comma,
                RowLeft = "(",
                RowRight = "),",
                WordLeft = "",
                WordRight = ""
            };

        public static SpreadsheetOutputProcessParameters QuickSqlStringInPreset =>
            new()
            {
                Delimiter = DelimiterEnum.Comma,
                RowRight = ",",
                WordLeft = "'",
                WordRight = "'"
            };

        public static SpreadsheetOutputProcessParameters QuickSqlNumericInPreset =>
            new()
            {
                Delimiter = DelimiterEnum.Comma,
                RowRight = ","
            };
    }
}