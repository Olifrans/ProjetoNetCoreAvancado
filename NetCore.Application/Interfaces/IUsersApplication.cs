using NetCore.Application.DataContract.Request.Client;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IUsersApplication


    Task<bool> AutheticationAsync(UsersModel users)
    

    Task CreateAsync(UsersModel users)
    

    Task DeleteAsync(string clientId)
    

    Task<UsersModel> GetByIdAsync(string usersId)
   

    Task<List<UsersModel>> GetListByFilterAsync(string usersId = null, string name = null)
   

    Task UpdateAsync(UsersModel users)
   

}