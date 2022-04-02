using Common.Items;

namespace Common.Interfaces
{
    public interface ISpreadsheetProcessor
    {
        SpreadsheetInputProcessResult ProcessInput(string text,
            SpreadsheetInputProcessParameters parameters);

        SpreadsheetOutputProcessResult ProcessOutput(GridParsingResult gridParsingResult,
            SpreadsheetOutputProcessParameters parameters);

        SpreadsheetOutputProcessResult RemoveRowDuplicates(string text);
    }
}