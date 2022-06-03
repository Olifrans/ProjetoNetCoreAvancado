using Dapper;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Models;

namespace NetCore.Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnector _dbConnector;

        public UsersRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        private const string baseSql = @"SELECT [Id]
                                      ,[Name]
                                      ,[Login]
                                      ,[PasswordHash]
                                      ,[CreatedAt]
                                  FROM [dbo].[Users]
                                  WHERE 1 = 1";

        //ok
        public async Task CreateAsync(UsersModel users)
        {
            string sql = @"INSERT INTO [dbo].[Users]
                                   ([Id]
                                   ,[Name]
                                   ,[Login]
                                   ,[PasswordHash]
                                   ,[CreatedAt])
                             VALUES
                                   (@Id
                                   ,@Name
                                   ,@Login
                                   ,@PasswordHash
                                   ,@CreatedAt)";
            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = users.Id,
                Name = users.Name,
                Login = users.Login,
                PasswordHash = users.PasswordHash,
                CreatedAt = users.CreatedAt,
            }, _dbConnector.dbTransaction);
        }

        //ok
        public async Task UpdateAsync(UsersModel users)
        {
            string sql = @"UPDATE[dbo].[Users]
                               SET [Name] = @Name
                                  ,[Login] = @Login
                                  ,[PasswordHash] = @PasswordHash
                             WHERE id = @Id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = users.Id,
                Name = users.Name,
                Login = users.Login,
                PasswordHash = users.PasswordHash,
            }, _dbConnector.dbTransaction);
        }

        //ok
        public async Task DeleteAsync(string usersId)
        {
            string sql = $"DELETE FROM [dbo].[Users] WHERE id = @id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { Id = usersId }, _dbConnector.dbTransaction);
        }

        //ok
        public async Task<bool> ExistsByIdAsync(string usersId)
        {
            string sql = $"SELECT 1 FROM Users WHERE Id = @Id";

            var users = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = usersId }, _dbConnector.dbTransaction);

            return users.FirstOrDefault();
        }

        //ok
        public async Task<bool> ExistsByLoginAsync(string login)
        {
            string sql = $"SELECT 1 FROM [User] WHERE Login = @Login ";

            var users = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Login = login }, _dbConnector.dbTransaction);

            return users.FirstOrDefault();
        }

        //ok
        public async Task<UsersModel> GetByIdAsync(string usersId)
        {
            string sql = $"{baseSql} AND Id = @Id ";

            var users = await _dbConnector.dbConnection.QueryAsync(sql, new { Id = usersId }, _dbConnector.dbTransaction);

            return users.FirstOrDefault();
        }

        public async Task<List<UsersModel>> GetListByFilterAsync(string login = null, string name = null)
        {
            string sql = $"{baseSql} ";

            if (!string.IsNullOrWhiteSpace(login))
                sql += "AND login =  @Login";

            if (!string.IsNullOrWhiteSpace(name))
                sql += "AND Name like  @Name";

            var users = await _dbConnector.dbConnection.QueryAsync<UsersModel>(sql, new { Login = login, Name = "%" + name + "%" }, _dbConnector.dbTransaction);

            return users.ToList();
        }

        public async Task<UsersModel> GetByLoginAsync(string login)
        {
            string sql = $"{baseSql} AND Login = @Login";

            var users = await _dbConnector.dbConnection.QueryAsync<UsersModel>(sql, new { Login = login }, _dbConnector.dbTransaction);

            return users.FirstOrDefault();
        }
    }
}