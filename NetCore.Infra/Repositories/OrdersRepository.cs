using Dapper;
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

        private const string baseSql = @"SELECT o.[Id]
                                          ,o.[CreatedAt]
                                          ,c.id
                                          ,c.[Name]
                                          ,u.id
                                          ,u.[Name]
                                      FROM [dbo].[Orders] o
                                      JOIN [dbo].[Client] c ON o.ClientId = c.Id
                                      JOIN [dbo].[[Users]] u ON o.UsersId = u.Id
                                      WHERE 1 = 1 ";

        public async Task CreateAsync(OrdersModel orders)
        {
            string sql = @"INSERT INTO [dbo].[Orders]
                                 ([Id]
                                 ,[ClientId]
                                 ,[UsersId]
                                 ,[CreatedAt])
                           VALUES
                                 (@Id
                                 ,@ClientId
                                 ,@UsersId
                                 ,@CreatedAt)";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = orders.Id,
                ClientId = orders.Client.Id,
                UserId = orders.Users.Id,
                CreatedAt = orders.CreatedAt
            }, _dbConnector.dbTransaction);

            if (orders.Items.Any())
            {
                foreach (var item in orders.Items)
                {
                    await CreateItemAsync(item);
                }
            }
        }

        public async Task CreateItemAsync(OrderItemModel item)
        {
            string sql = $"{baseSql} ";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = item.Id,
                OrdersId = item.Orders.Id,
                ProductId = item.Product.Id,
                SelValue = item.SelValue,
                Quantity = item.Quantity,
                TotalAmount = item.TotalAmount,
                CreatedAt = item.CreatedAt,
            }, _dbConnector.dbTransaction);
        }

        public async Task DeleteAsync(string ordersId)
        {
            string sql = $"DELETE FROM [dbo].[Order] WHERE id = @id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { Id = ordersId }, _dbConnector.dbTransaction);
        }

        public async Task DeleteItemAsync(string itemId)
        {
            string sql = $"DELETE FROM [dbo].[OrderItem] WHERE id = @id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { Id = itemId }, _dbConnector.dbTransaction);
        }

        public async Task<bool> ExistsByIdAsync(string ordersId)
        {
            string sql = $"SELECT 1 FROM [Order] WHERE Id = @Id ";

            var order = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = ordersId }, _dbConnector.dbTransaction);

            return order.FirstOrDefault();
        }
             
        public async Task<OrdersModel> GetByIdAsync(string ordersId)
        {
            string sql = $"{baseSql} AND Id =  @Id";

            var orders = await _dbConnector.dbConnection.QueryAsync<OrdersModel, ClientModel, UsersModel, OrdersModel>(
                sql: sql,
                map: (order, client, users) =>
                {
                    order.Client = client;
                    order.Users = users;
                    return order;
                },
                param: new { Id = ordersId },
                splitOn: "Id",
                transaction: _dbConnector.dbTransaction);

            return orders.FirstOrDefault();
        }

        public async Task<List<OrdersModel>> GetListByFilterAsync(string ordersId = null, string clientId = null, string usersId = null)
        {
            string sql = $"{baseSql} ";

            if (string.IsNullOrWhiteSpace(ordersId))
                sql += "AND o.Id = @ordersId";

            if (string.IsNullOrWhiteSpace(clientId))
                sql += "AND o.clientId = @clientId";

            if (string.IsNullOrWhiteSpace(usersId))
                sql += "AND o.usersId = @usersId";

            var orders = await _dbConnector.dbConnection.QueryAsync<OrdersModel, ClientModel, UsersModel, OrdersModel>(
                sql: sql,
                map: (order, client, users) =>
                {
                    order.Client = client;
                    order.Users = users;
                    return order;
                },
                param: new { OrdersId = ordersId, ClientId = clientId, UsersId = usersId },
                 splitOn: "Id",
                transaction: _dbConnector.dbTransaction);

            return orders.ToList();
        }

           public async Task<List<OrderItemModel>> GetListByOrderIdAsync(string ordersId)
        {
            string sql = @"SELECT [Id]
                              ,oi.[SelValue]
                              ,oi.[Quantity]
                              ,oi.[TotalAmount]
                              ,oi.[CreatedAt]
                              ,oi.[OrdersId] as id
                              ,oi.[ProductId] as id
                              ,p.[Description]
                          FROM [dbo].[OrderItem] oi
                          JOIN [dbo].[Product] p on oi.ProductId = p.id
                          WHERE oi.OrdersId = @OrdersId";

            var items = await _dbConnector.dbConnection.QueryAsync<OrderItemModel, OrdersModel, ProductModel, OrderItemModel>(
               sql: sql,
                map: (item, order, prod) =>
                {
                    item.Orders = order;
                    item.Product = prod;
                    return item;
                },
                param: new { OrdersId = ordersId },
                splitOn: "Id",
                transaction: _dbConnector.dbTransaction);

            return items.ToList();
        }

        public async Task UpdateAsync(OrdersModel orders)
        {
            string sql = @"UPDATE [dbo].[Orders]
                            SET [ClientId] = @ClientId
                               ,[UsersId] = @UsersId
                          WHERE id = @Id ";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = orders.Id,
                ClientId = orders.Client.Id,
                UserId = orders.Users.Id
            }, _dbConnector.dbTransaction);

            if (orders.Items.Any())
            {
                string deleteItem = $"DELETE FROM [dbo].[OrderItem] WHERE OrderId = @OrderId";

                await _dbConnector.dbConnection.ExecuteAsync(deleteItem, new { OrderId = orders.Id }, _dbConnector.dbTransaction);

                foreach (var item in orders.Items)
                {
                    await CreateItemAsync(item);
                }
            }
        }
    }
}

//public async Task UpdateItemAsync(OrderItemModel item)
//{
//    string sql = @"UPDATE [dbo].[Order]
//                    SET [ClientId] = @ClientId
//                       ,[UserId] = @UserId
//                  WHERE id = @Id ";

//    await _dbConnector.dbConnection.ExecuteAsync(sql, new
//    {
//        Id = order.Id,
//        ClientId = order.Client.Id,
//        UserId = order.User.Id
//    }, _dbConnector.dbTransaction);

//    if (order.Items.Any())
//    {
//        string deleteItem = $"DELETE FROM [dbo].[OrderItem] WHERE OrderId = @OrderId";

//        await _dbConnector.dbConnection.ExecuteAsync(deleteItem, new { OrderId = order.Id }, _dbConnector.dbTransaction);

//        foreach (var item in order.Items)
//        {
//            await CreateItemAsync(item);
//        }
//    }
//}