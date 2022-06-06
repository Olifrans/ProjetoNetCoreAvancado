using AutoMapper;
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

    public UsersApplication(IUsersService usersService, IMapper mapper)
    {
        _usersService = usersService;
        _mapper = mapper;
    }

    public Task<Response<AuthResponse>> AuthAsync(AuthRequest auth)
    {
        throw new NotImplementedException();
    }

    public async Task<Response> CreateAsync(CreateUsersRequest User)
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

    public async Task<Response<List<UsersResponse>>> GetListByFilterAsync(string userId = null, string name = null)
    {
        Response<List<UsersModel>> users = await _usersService.GetListByFilterAsync(userId, name);

        if (users.Reports.Any())
            return Response.Unprocessable<List<UsersResponse>>(users.Reports);

        var response = _mapper.Map<List<UsersResponse>>(users.Data);

        return Response.Ok(response);
    }
}