using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace NetCore.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IClientRepository _clientRepository;
    private IProductRepository _productRepository;
    private IOrdersRepository _ordersRepository;
    private IUsersRepository _usersRepository;

    public UnitOfWork(IDbConnector dbConnector)
    {
        this.dbConnector = dbConnector;
    }

    public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(dbConnector));

    public IOrdersRepository OrdersRepository => _ordersRepository ?? (_ordersRepository = new OrdersRepository(dbConnector));

    public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(dbConnector));

    public IUsersRepository UsersRepository => _usersRepository ?? (_usersRepository = new UsersRepository(dbConnector));


    public IDbConnector dbConnector { get; }


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