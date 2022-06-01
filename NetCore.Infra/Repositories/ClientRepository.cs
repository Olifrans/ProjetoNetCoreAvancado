using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Models;
using System.Data;

namespace NetCore.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;
        public ClientRepository(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public Task CreateAsync(ClientModel client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<ClientModel> GetByIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientModel>> GetListByFilterAsync(string clientId = null, string name = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}