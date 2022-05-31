using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

namespace NetCore.Domain.Interfaces.Services;

public interface IClientService
{
    Task<Response> CreateAsync(ClientModel client);

    Task<Response> UpdateAsync(ClientModel client);

    Task<Response> DeleteAsync(string clientId);

    Task<Response<ClientModel>> GetByIdAsync(string clientId);

    Task<Response<List<ClientModel>>> GetListByFilterAsync(string clientId = null, string name = null);
}