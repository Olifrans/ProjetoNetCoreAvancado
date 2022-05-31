using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Response.Client;
using NetCore.Domain.Models;

namespace NetCore.Application.Mapper;

public class Core : Profile
{
    public Core()
    {
        ClientMap();
    }

    private void ClientMap()
    {
        CreateMap<CreateClientRequest, ClientModel>();

        CreateMap<ClientModel, ClientResponse>();
    }
}