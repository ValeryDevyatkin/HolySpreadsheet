using System.Collections.Generic;
using Common.Items;

namespace Common.Interfaces
{
    public interface ISpreadsheetProcessor
    {
        SpreadsheetInputProcessResult ProcessInput(string text,
                                                   SpreadsheetInputProcessParameters parameters);

        SpreadsheetOutputProcessResult ProcessOutput(IReadOnlyList<IEnumerable<string>> rows,
                                                     SpreadsheetOutputProcessParameters parameters);

        SpreadsheetOutputProcessResult RemoveRowDuplicates(string text);
    }
}