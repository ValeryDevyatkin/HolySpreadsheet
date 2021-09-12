using System.Collections.Generic;
using Common.Items;

namespace Common.Interfaces
{
    public interface ISpreadsheetProcessor
    {
        IReadOnlyList<string[]> ProcessInput(SpreadsheetInputParseParameters parameters);
        string ProcessOutput(SpreadsheetOutputProcessParameters parameters);
    }
}