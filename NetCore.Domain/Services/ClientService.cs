using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;

namespace NetCore.Domain.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
        this._clientRepository = clientRepository;
    }



    public Task CreateAsync(ClientModel client)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string clientId)
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