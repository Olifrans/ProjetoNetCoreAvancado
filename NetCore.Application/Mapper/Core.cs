using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Request.Orders;
using NetCore.Application.DataContract.Request.Product;
using NetCore.Application.DataContract.Request.Users;
using NetCore.Application.DataContract.Response.Client;
using NetCore.Application.DataContract.Response.Orders;
using NetCore.Application.DataContract.Response.Product;
using NetCore.Application.DataContract.Response.Users;
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