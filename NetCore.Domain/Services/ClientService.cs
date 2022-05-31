using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;
using NetCore.Domain.Validations;
using NetCore.Domain.Validations.Base;

namespace NetCore.Domain.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
        this._clientRepository = clientRepository;
    }






    async Task<Response> IClientService.CreateAsync(ClientModel client)
    {
        var response = new Response();

        var validation = new ClientValidation();
        var result = validation.Validate(client);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                response.Reports.Add(new Reports()
                {
                    Code = error.PropertyName,
                    Message = error.ErrorMessage
                });
            }
            return response;
        }

        await _clientRepository.CreateAsync(client);
        return response;
    }



    Task<Response> IClientService.DeleteAsync(string clientId)
    {
        throw new NotImplementedException();
    }

    Task<Response<ClientModel>> IClientService.GetByIdAsync(string clientId)
    {
        throw new NotImplementedException();
    }

    Task<Response<List<ClientModel>>> IClientService.GetListByFilterAsync(string clientId, string name)
    {
        throw new NotImplementedException();
    }

    Task<Response> IClientService.UpdateAsync(ClientModel client)
    {
        throw new NotImplementedException();
    }
}