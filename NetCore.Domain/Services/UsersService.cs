using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;

namespace NetCore.Domain.Services;

public class UsersService : IUsersService
{
    private IUsersRepository _usersRepository;
    public UsersService(IUsersRepository usersRepository)
    {
        this._usersRepository = usersRepository;
    }




    public Task<bool> AutheticationAsync(UsersModel users)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(UsersModel users)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string clientId)
    {
        throw new NotImplementedException();
    }

    public Task<UsersModel> GetByIdAsync(string usersId)
    {
        throw new NotImplementedException();
    }

    public Task<List<UsersModel>> GetListByFilterAsync(string usersId = null, string name = null)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UsersModel users)
    {
        throw new NotImplementedException();
    }
}