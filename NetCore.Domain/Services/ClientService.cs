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

    public async Task<Response> CreateAsync(ClientModel client)
    //public async Task<Response> IClientService.CreateAsync(ClientModel client)
    {
        var response = new Response();

        var validation = new ClientValidation();
        var errors = validation.Validate(client).GetErrors();

        if (errors.Reports.Count > 0)
            return errors;

        await _clientRepository.CreateAsync(client);
        return response;
    }

    public async Task<Response> DeleteAsync(string clientId)
    //public async Task<Response> IClientService.DeleteAsync(string clientId)
    {
        var response = new Response();

        var exists = await _clientRepository.ExistsByIdAsync(clientId);

        if (!exists)
        {
            response.Reports.Add(Reports.Create($"Client {clientId} not exists!"));
            return response;
        }
        await _clientRepository.DeleteAsync(clientId);

        return response;
    }

    public async Task<Response<ClientModel>> GetByIdAsync(string clientId)
    //public async Task<Response<ClientModel>> IClientService.GetByIdAsync(string clientId)
    {
        var response = new Response<ClientModel>();

        var exists = await _clientRepository.ExistsByIdAsync(clientId);

        if (!exists)
        {
            response.Reports.Add(Reports.Create($"Client {clientId} not exists!"));
            return response;
        }
        var data = await _clientRepository.GetByIdAsync(clientId);
        response.Data = data;
        return response;
    }

    public async Task<Response<List<ClientModel>>> GetListByFilterAsync(string clientId = null, string name = null)
    //async Task<Response<List<ClientModel>>> IClientService.GetListByFilterAsync(string clientId = null, string name = null)
    {
        var response = new Response<List<ClientModel>>();

        if (!string.IsNullOrWhiteSpace(clientId))
        {
            var exists = await _clientRepository.ExistsByIdAsync(clientId);

            if (!exists)
            {
                response.Reports.Add(Reports.Create($"Client {clientId} not exists!"));
                return response;
            }
        }
        var data = await _clientRepository.GetListByFilterAsync(clientId, name);
        response.Data = data;

        return response;
    }

    public async Task<Response> UpdateAsync(ClientModel client)
    //public async Task<Response> IClientService.UpdateAsync(ClientModel client)
    {
        var response = new Response();

        var validation = new ClientValidation();
        var errors = validation.Validate(client).GetErrors();

        if (errors.Reports.Count > 0)
            return errors;

        var exists = await _clientRepository.ExistsByIdAsync(client.Id);

        if (!exists)
        {
            response.Reports.Add(Reports.Create($"Client {client.Id} not exists!"));
            return response;
        }
        await _clientRepository.UpdateAsync(client);

        return response;
    }
}