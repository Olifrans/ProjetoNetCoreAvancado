using NetCore.Domain.Common;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Service;
using NetCore.Domain.Models;
using NetCore.Domain.Validations;
using NetCore.Domain.Validations.Base;

namespace NetCore.Domain.Services;

public class ClientService : IClientsService
{

    private readonly IClientRepository _clientRepository;
    private readonly IGeneretors _generetors;
    private readonly ITimeProvider _timeProvider;
    public ClientService(IClientRepository clientRepository, IGeneretors generetors, ITimeProvider timeProvider)
    {
        this._clientRepository = clientRepository;
        this._generetors = generetors;
        this._timeProvider = timeProvider;
    }

    

    //ok
    public async Task<Response> CreateAsync(ClientModel client)
    {
        var response = new Response();

        var validation = new ClientValidation();
        var errors = validation.Validate(client).GetErrors();

        if (errors.Reports.Count > 0)
            return errors;

        client.Id = _generetors.Generate();
        client.CreatedAt = _timeProvider.utcDateTime();

        await _clientRepository.CreateAsync(client);
        return response;
    }



    public async Task<Response> DeleteAsync(string clientId)
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