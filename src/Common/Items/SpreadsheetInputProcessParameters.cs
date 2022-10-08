using Common.Enums;

namespace Common.Items
{
    public class SpreadsheetInputProcessParameters
    {
        public DelimiterEnum Delimiter { get; set; }
        public string CustomDelimiter { get; set; }
        public bool ShouldPullInLine { get; set; }
    }
}