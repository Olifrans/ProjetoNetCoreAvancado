using Dapper;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Models;

namespace NetCore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnector _dbConnector;

        public ProductRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        private const string baseSql = @"SELECT [Id]
                                       ,[Name]
                                       ,[Email]
                                       ,[PhoneNumber]
                                       ,[Adress]
                                       ,[CreatedAt])
                                  FROM [dbo].[Product]
                                  WHERE 1 = 1";

        //ok
        public async Task CreateAsync(ProductModel product)
        {
            string sql = @"INSERT INTO [dbo].[Product]
                                       ([Id]
                                       ,[Description]
                                       ,[SelValue]
                                       ,[Stock]
                                       ,[CreatedAt])
                                 VALUES
                                       (@Id
                                       ,@Description
                                       ,@SelValue
                                       ,@Stock
                                       ,@CreatedAt)";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = product.Id,
                Description = product.Description,
                SelValue = product.SelValue,
                Stock = product.Stock,
                CreatedAt = product.CreatedAt,
            }, _dbConnector.dbTransaction);
        }

        //ok
        public async Task DeleteAsync(string productId)
        {
            string sql = $"DELETE FROM [dbo].[Product] WHERE id = @id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { Id = productId }, _dbConnector.dbTransaction);
        }

        //ok
        public async Task<bool> ExistsByIdAsync(string productId)
        {
            string sql = $"SELECT 1 FROM Product WHERE Id = @Id ";

            var Products = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = productId }, _dbConnector.dbTransaction);

            return Products.FirstOrDefault();
        }

        //ok
        public async Task<ProductModel> GetByIdAsync(string productId)
        {
            string sql = $"{baseSql} AND Id = @Id";

            var Products = await _dbConnector.dbConnection.QueryAsync<ProductModel>(sql, new { Id = productId }, _dbConnector.dbTransaction);

            return Products.FirstOrDefault();
        }

        public async Task<List<ProductModel>> GetListByFilterAsync(string productId = null, string name = null)
        {
            string sql = $"{baseSql} ";

            if (!string.IsNullOrWhiteSpace(productId))
                sql += "AND Id = @Id";

            if (!string.IsNullOrWhiteSpace(name))
                sql += "AND Description like @Name";

            var products = await _dbConnector.dbConnection.QueryAsync<ProductModel>(sql, new { Id = productId, Name = "%" + name + "%" }, _dbConnector.dbTransaction);

            return products.ToList();
        }

        public async Task UpdateAsync(ProductModel product)
        {
            string sql = @"UPDATE [dbo].[Product]
                               SET [Description] = @Description
                                  ,[SellValue] = @SellValue
                                  ,[Stock] = @Stock
                           WHERE Id = @Id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = product.Id,
                Description = product.Description,
                SelValue = product.SelValue,
                Stock = product.Stock
            }, _dbConnector.dbTransaction);
        }
    }
}