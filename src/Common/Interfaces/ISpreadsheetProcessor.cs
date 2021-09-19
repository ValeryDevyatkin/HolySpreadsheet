using System.Collections.Generic;
using Common.Items;

namespace Common.Interfaces
{
    public interface ISpreadsheetProcessor
    {
        SpreadsheetProcessResult ProcessInput(string text,
                                              SpreadsheetInputProcessParameters parameters);

        string ProcessOutput(IEnumerable<IEnumerable<string>> rows,
                             SpreadsheetOutputProcessParameters parameters);
    }
}