using System;
using System.Collections.Generic;
using Common.Interfaces;
using Unity;

namespace WpfClient.Services
{
    internal class DataGridService : IDataGridService
    {
        public DataGridService(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public void FillGrid(IEnumerable<IEnumerable<string>> rows)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEnumerable<string>> GetRows() => throw new NotImplementedException();
    }
}