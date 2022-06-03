using NetCore.Domain.Models;

namespace NetCore.Domain.Interfaces.Repositories;
public interface IUsersRepository
{
    Task CreateAsync(UsersModel users);

    Task UpdateAsync(UsersModel users);

    Task DeleteAsync(string usersId);


    Task<UsersModel> GetByIdAsync(string usersId);

    Task<UsersModel> GetByLoginAsync(string login);

    Task<List<UsersModel>> GetListByFilterAsync(string usersId = null, string name = null);   

    Task<bool> ExistsByIdAsync(string usersId);
    Task<bool> ExistsByLoginAsync(string login);

}