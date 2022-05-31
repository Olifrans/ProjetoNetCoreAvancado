using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

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
        var clientModel = _mapper.Map<ClientModel>(clientRequest);
        return await _clientService.CreateAsync(clientModel);
    }
}