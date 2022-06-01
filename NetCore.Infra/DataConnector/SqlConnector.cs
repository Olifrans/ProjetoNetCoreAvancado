using NetCore.Domain.Interfaces.Repositories.DataConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Infra.DataConnector
{
    public class SqlConnector : IDbConnector
    {
        public IDbConnection bdConnection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDbTransaction dbTransaction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
