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

        public Task CreateAsync(ClientModel client)
        {
            string sql = $"{baseSql} AND Id =  @Id";

            var clients = await _dbConnector.dbConnection.Execute<ClientModel>(sql, new { Id = clientId });

            return clients.FirstOrDefault();
        }

        public async Task DeleteAsync(string clientId)
        {
            string sql = $"{baseSql} AND Id =  @Id";

            var clients = await _dbConnector.dbConnection.Execute<ClientModel>(sql, new { Id = clientId });

            return clients.FirstOrDefault();
        }



        //ok
        public async Task<bool> ExistsByIdAsync(string clientId)
        {
            string sql = $"SELECT 1 FROM Client WHERE Id = @Id";

            var clients = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = clientId }, _dbConnector.dbTransaction);

            return clients.FirstOrDefault();
        }

        //ok
        public async Task<ClientModel> GetByIdAsync(string clientId)
        {
            string sql = $"{baseSql} AND Id =  @Id";

            var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new { Id = clientId }, _dbConnector.dbTransaction);

            return clients.FirstOrDefault();
        }

        //ok
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






        public Task UpdateAsync(ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}