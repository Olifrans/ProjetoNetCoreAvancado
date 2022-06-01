using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace NetCore.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IClientRepository _clientRepository;

    public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(dbConnector.dbConnection));


    public IOrdersRepository OrdersRepository => throw new NotImplementedException();

    public IProductRepository ProductRepository => throw new NotImplementedException();

    public IUsersRepository UsersRepository => throw new NotImplementedException();

    public IDbConnector dbConnector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void BeginTransaction()
    {
        if (dbConnector.dbConnection.State == System.Data.ConnectionState.Open)
        {
            dbConnector.dbTransaction = dbConnector.dbConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
    }

    public void CommitTransaction()
    {
        if (dbConnector.dbConnection.State == System.Data.ConnectionState.Open)
        {
            dbConnector.dbTransaction.Commit();
        }
    }

    public void RollbackTransaction()
    {
        if (dbConnector.dbConnection.State == System.Data.ConnectionState.Open)
        {
            dbConnector.dbTransaction.Rollback();
        }
    }
}