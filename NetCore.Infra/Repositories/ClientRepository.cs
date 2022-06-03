using Dapper;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Models;

namespace NetCore.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnector _dbConnector;
        public ClientRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        private const string baseSql = @"SELECT [Id]
                                      ,[Name]
                                      ,[Email]
                                      ,[PhoneNumber]
                                      ,[Adress]
                                      ,[CreatedAt]
                                  FROM[dbo].[Client]
                                  WHERE 1 = 1";



        //ok Post
        public async Task CreateAsync(ClientModel client)
        {
            string sql = @$"INSERT INTO [dbo].[Client]
                                   ([Id]
                                   ,[Name]
                                   ,[Email]
                                   ,[PhoneNumber]
                                   ,[Adress]
                                   ,[CreatedAt])
                             VALUES
                                   (@Id
                                   ,@Name
                                   ,@Email
                                   ,@PhoneNumber
                                   ,@Adress
                                   ,@CreatedAt)";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Adress = client.Adress,
                CreatedAt = client.CreatedAt,
            }, _dbConnector.dbTransaction);
        }



        //ok Update
        public async Task UpdateAsync(ClientModel client)
        {
            string sql = @$"UPDATE [dbo].[Client]
                               SET [Name] = @Name
                                  ,[Email] = @Email
                                  ,[PhoneNumber] = @PhoneNumber
                                  ,[Adress] = @Adress
                             WHERE Id = @Id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Adress = client.Adress,
            }, _dbConnector.dbTransaction);
        }



        //ok Delete
        public async Task DeleteAsync(string clientId)
        {
            string sql = $" DELETE FROM[dbo].[Client] WHERE Id = @Id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { Id = clientId }, _dbConnector.dbTransaction);
        }



        //ok GetExistId
        public async Task<bool> ExistsByIdAsync(string clientId)
        {
            string sql = $"SELECT 1 FROM Client WHERE Id = @Id";

            var clients = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = clientId }, _dbConnector.dbTransaction);

            return clients.FirstOrDefault();
        }



        //ok GetId
        public async Task<ClientModel> GetByIdAsync(string clientId)
        {
            string sql = $"{baseSql} AND Id =  @Id";

            var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new { Id = clientId }, _dbConnector.dbTransaction);

            return clients.FirstOrDefault();
        }



        //ok GetAll
        public async Task<List<ClientModel>> GetListByFilterAsync(string clientId = null, string name = null)
        {
            string sql = $"{baseSql} ";

            if (string.IsNullOrWhiteSpace(clientId))
                sql += "AND Id =  @Id";

            if (string.IsNullOrWhiteSpace(name))
                sql += "AND Name like  @Name";

            var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new { Id = clientId, Name = "%" + name + "%" }, _dbConnector.dbTransaction);

            return clients.ToList();
        }
    }
}