using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Request.Users;
using NetCore.Application.DataContract.Response.Users;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Service;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Application;

public class UsersApplication : IUsersApplication
{
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public Task<Response<AuthResponse>> AuthAsync(AuthRequest auth)
    {
        throw new NotImplementedException();
    }

    public Task<Response> CreateAsync(CreateUsersRequest User)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<UsersResponse>>> ListByFilterAsync(string userId = null, string name = null)
    {
        throw new NotImplementedException();
    }


    //public async Task<Response> CreateAsync(CreateClientRequest clientRequest)
    //{
    //    var clientModel = _mapper.Map<ClientModel>(clientRequest);
    //    return await _clientService.CreateAsync(clientModel);
    //}
}