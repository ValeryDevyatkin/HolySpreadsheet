using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IDataGridService
    {
        void FillGrid(IEnumerable<IEnumerable<string>> rows);
        IEnumerable<IEnumerable<string>> GetRows();
    }
}