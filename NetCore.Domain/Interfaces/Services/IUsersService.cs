using NetCore.Domain.Models;

namespace NetCore.Domain.Interfaces.Repositories;

public interface IUsersService
{
    Task<bool> AutheticationAsync(UsersModel users);

    Task CreateAsync(UsersModel users);

    Task UpdateAsync(UsersModel users);

    Task DeleteAsync(string clientId);

    Task<UsersModel> GetByIdAsync(string usersId);

    Task<List<UsersModel>> GetListByFilterAsync(string usersId = null, string name = null);
}