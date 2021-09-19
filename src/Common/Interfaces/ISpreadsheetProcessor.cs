using System.Collections.Generic;
using Common.Items;

namespace Common.Interfaces
{
    public interface ISpreadsheetProcessor
    {
        IEnumerable<IEnumerable<string>> ProcessInput(string text,
                                                      SpreadsheetInputParseParameters parameters);

        string ProcessOutput(IEnumerable<IEnumerable<string>> rows,
                             SpreadsheetOutputProcessParameters parameters);
    }
}