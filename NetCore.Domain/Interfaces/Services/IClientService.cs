using NetCore.Domain.Models;

namespace NetCore.Domain.Interfaces.Services;

public interface IClientService
{
    Task CreateAsync(ClientModel client);

    Task UpdateAsync(ClientModel client);

    Task DeleteAsync(string clientId);

    Task<ClientModel> GetByIdAsync(string clientId);

    Task<List<ClientModel>> GetListByFilterAsync(string clientId = null, string name = null);
}