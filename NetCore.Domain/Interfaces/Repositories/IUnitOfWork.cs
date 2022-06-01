using NetCore.Domain.Interfaces.Repositories.DataConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IProductRepository ProductRepository { get; }
        IUsersRepository UsersRepository { get; }

        IDbConnector dbConnector { get; set; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        //void CloseTransaction();

       


    }
}


