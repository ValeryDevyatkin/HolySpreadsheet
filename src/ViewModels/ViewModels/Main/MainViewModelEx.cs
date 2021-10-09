using Common.Items;

namespace ViewModels
{
    internal static class MainViewModelEx
    {
        public static SpreadsheetOutputProcessParameters GetOutputProcessParameters(this MainViewModel item) =>
            new SpreadsheetOutputProcessParameters
            {
                CustomDelimiter = item.OutputParserConfiguration.CustomDelimiter,
                Delimiter = item.OutputParserConfiguration.Delimiter,
                RowLeft = item.OutputParserConfiguration.RowLeft,
                RowRight = item.OutputParserConfiguration.RowRight,
                WordLeft = item.OutputParserConfiguration.WordLeft,
                WordRight = item.OutputParserConfiguration.WordRight,
                TextCase = item.OutputTextCase
            };

        public static SpreadsheetInputProcessParameters GetInputProcessParameters(this MainViewModel item) =>
            new SpreadsheetInputProcessParameters
            {
                CustomDelimiter = item.InputParserConfiguration.CustomDelimiter,
                Delimiter = item.InputParserConfiguration.Delimiter,
                RowLeft = item.InputParserConfiguration.RowLeft,
                RowRight = item.InputParserConfiguration.RowRight,
                WordLeft = item.InputParserConfiguration.WordLeft,
                WordRight = item.InputParserConfiguration.WordRight
            };
    }
}