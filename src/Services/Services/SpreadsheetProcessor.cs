using System;
using System.Collections.Generic;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace Services.Services
{
    internal class SpreadsheetProcessor : ISpreadsheetProcessor
    {
        public SpreadsheetProcessor(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public IReadOnlyList<string[]> ProcessInput(SpreadsheetInputParseParameters parameters) =>
            throw new NotImplementedException();

        public string ProcessOutput(SpreadsheetOutputProcessParameters parameters) =>
            throw new NotImplementedException();
    }
}