using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;
using NetCore.Domain.Validations;

namespace NetCore.Domain.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
        this._clientRepository = clientRepository;
    }



    public async Task CreateAsync(ClientModel client)
    {
        var validation = new ClientValidation();
        var result = validation.Validate(client);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                
            }    
        }


        _clientRepository.CreateAsync(client);

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