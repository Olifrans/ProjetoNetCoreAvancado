using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Models;

namespace NetCore.Infra.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IDbConnector _dbConnector;

        public OrdersRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        public Task CreateAsync(OrdersModel orders)
        {
            throw new NotImplementedException();
        }

        public Task CreateItemAsync(OrderItemModel item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string ordersId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(string ordersId)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersModel> GetByIdAsync(string ordersId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrdersModel>> GetListByFilterAsync(string ordersId = null, string clientId = null, string usersId = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItemModel>> GetListByOrderIdAsync(string ordersId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrdersModel orders)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(OrderItemModel item)
        {
            throw new NotImplementedException();
        }

        //private const string baseSql = @"SELECT [Id]
        //                              ,[Name]
        //                              ,[Email]
        //                              ,[PhoneNumber]
        //                              ,[Adress]
        //                              ,[CreatedAt]
        //                          FROM[dbo].[Client]
        //                          WHERE 1 = 1";

        //public Task CreateAsync(ClientModel client)
        //{
        //    string sql = $"{baseSql} AND Id =  @Id";

        //    var clients = await _dbConnector.dbConnection.Execute<ClientModel>(sql, new { Id = clientId });

        //    return clients.FirstOrDefault();
        //}

        //public async Task DeleteAsync(string clientId)
        //{
        //    string sql = $"{baseSql} AND Id =  @Id";

        //    var clients = await _dbConnector.dbConnection.Execute<ClientModel>(sql, new { Id = clientId });

        //    return clients.FirstOrDefault();
        //}

        ////ok
        //public async Task<bool> ExistsByIdAsync(string clientId)
        //{
        //    string sql = $"SELECT 1 FROM Client WHERE Id = @Id";

        //    var clients = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = clientId }, _dbConnector.dbTransaction);

        //    return clients.FirstOrDefault();
        //}

        ////ok
        //public async Task<ClientModel> GetByIdAsync(string clientId)
        //{
        //    string sql = $"{baseSql} AND Id =  @Id";

        //    var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new { Id = clientId }, _dbConnector.dbTransaction);

        //    return clients.FirstOrDefault();
        //}

        ////ok
        //public async Task<List<ClientModel>> GetListByFilterAsync(string clientId = null, string name = null)
        //{
        //    string sql = $"{baseSql} ";

        //    if (string.IsNullOrWhiteSpace(clientId))
        //        sql += "AND Id =  @Id";

        //    if (string.IsNullOrWhiteSpace(name))
        //        sql += "AND Name like  @Name";

        //    var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new { Id = clientId, Name = "%" + name + "%" }, _dbConnector.dbTransaction);

        //    return clients.ToList();
        //}

        //public Task UpdateAsync(ClientModel client)
        //{
        //    throw new NotImplementedException();
        //}
    }
}