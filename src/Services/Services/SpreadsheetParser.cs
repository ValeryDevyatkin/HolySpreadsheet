using Common.Interfaces;
using Unity;

namespace Services.Services
{
    internal class SpreadsheetParser : ISpreadsheetParser
    {
        public SpreadsheetParser(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }
    }
}