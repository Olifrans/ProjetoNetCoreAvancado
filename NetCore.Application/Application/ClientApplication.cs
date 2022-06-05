using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Response.Client;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;
using System;

namespace NetCore.Application.Application;

public class ClientApplication : IClientApplication
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public ClientApplication(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

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

    public Task<Response> DeleteAsync(string clientId)
    {
        throw new NotImplementedException();
    }

    public Task<Response> GetByIdAsync(string clientId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<List<ClientResponse>>> GetListByFilterAsync(string clientId, string name)
    {
        Response<List<ClientModel>> client = await _clientService.GetListByFilterAsync(clientId, name);

        if (client.Reports.Any())
            return Response.Unprocessable<List<ClientResponse>>(client.Reports);

        var response = _mapper.Map<List<ClientResponse>>(client.Data);

        return Response.Ok(response);
    }

    public Task<Response> UpdateAsync(ClientModel client)
    {
        throw new NotImplementedException();
    }
}