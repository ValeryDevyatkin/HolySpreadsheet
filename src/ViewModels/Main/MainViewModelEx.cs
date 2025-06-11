using Common.Enums;
using Common.Items;

namespace ViewModels.Main
{
    internal static partial class MainViewModelEx
    {
        public static SpreadsheetOutputProcessParameters GetOutputProcessParameters(this MainViewModel item)
        {
            var conf = item.OutputParserConfiguration;

            var param = new SpreadsheetOutputProcessParameters
            {
                CustomDelimiter = conf.CustomDelimiter,
                Delimiter = conf.Delimiter
            };

            switch (conf.CellWrapper)
            {
                case CellWrapperEnum.Quotes:
                {
                    param.WordLeft = param.WordRight = "'";

                    break;
                }

                case CellWrapperEnum.DoubleQuotes:
                {
                    param.WordLeft = param.WordRight = "\"";

                    break;
                }

                case CellWrapperEnum.Custom:
                {
                    param.WordLeft = conf.WordLeft?.Trim();
                    param.WordRight = conf.WordRight?.Trim();

                    break;
                }
            }

            switch (conf.RowWrapper)
            {
                case RowWrapperEnum.Coma:
                {
                    param.RowRight = ",";

                    break;
                }

                case RowWrapperEnum.ParenthesesAndComa:
                {
                    param.RowLeft = "(";
                    param.RowRight = "),";

                    break;
                }

                case RowWrapperEnum.Custom:
                {
                    param.RowLeft = conf.RowLeft?.Trim();
                    param.RowRight = conf.RowRight?.Trim();

                    break;
                }
            }

            return param;
        }

        public static SpreadsheetInputProcessParameters GetInputProcessParameters(this MainViewModel item) =>
            new()
            {
                CustomDelimiter = item.CustomDelimiter,
                Delimiter = item.Delimiter,
                ShouldPullInLine = item.ShouldPullInLine
            };

        public static void SetOutputProcessResult(this MainViewModel item, SpreadsheetOutputProcessResult result)
        {
            item.OutputRowCount = result.RowCount;
            item.OutputText = result.Text;
        }
    }
}