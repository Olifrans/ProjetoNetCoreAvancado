using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Response.Client;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Service;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;
using System;

namespace NetCore.Application.Application;

public class ClientApplication : IClientApplication
{
    private readonly IClientsService _clientService;
    private readonly IMapper _mapper;

    public ClientApplication(IClientsService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

    //ok
    public async Task<Response> CreateAsync(CreateClientRequest clientRequest)
    {
        try
        {
            var clientModel = _mapper.Map<ClientModel>(clientRequest);

            return await _clientService.CreateAsync(clientModel);
        }
        catch (Exception ex)
        {

            var response = Reports.Create(ex.Message);

            return Response.Unprocessable(response);
        }
    }

    //ok
    public async Task<Response> DeleteAsync(string clientId)
    {
        return await _clientService.DeleteAsync(clientId);
    }


    //ok
    public async Task<Response<ClientResponse>> GetByIdAsync(string clientId)
    {
        Response<ClientModel> client = await _clientService.GetByIdAsync(clientId);

        if (client.Reports.Any())
            return Response.Unprocessable<ClientResponse>(client.Reports);

        var response = _mapper.Map<ClientResponse>(client.Data);

        return Response.Ok(response);
    }


    //ok
    public async Task<Response<List<ClientResponse>>> GetListByFilterAsync(string clientId, string name)
    {
        Response<List<ClientModel>> client = await _clientService.GetListByFilterAsync(clientId, name);

        if (client.Reports.Any())
            return Response.Unprocessable<List<ClientResponse>>(client.Reports);

        var response = _mapper.Map<List<ClientResponse>>(client.Data);

        return Response.Ok(response);
    }


    //ok
    public async Task<Response> UpdateAsync(UpdateClientRequest updateClientRequest)
    {
        var clientModel = _mapper.Map<ClientModel>(updateClientRequest);

        return await _clientService.UpdateAsync(clientModel);
    }    
}