using NetCore.Application.DataContract.Request.Users;
using NetCore.Application.DataContract.Response.Users;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IUsersApplication
{
    Task<Response<AuthResponse>> AuthAsync(AuthRequest auth);

    Task<Response> CreateAsync(CreateUsersRequest User);

    Task<Response<List<UsersResponse>>> ListByFilterAsync(string userId = null, string name = null);
}