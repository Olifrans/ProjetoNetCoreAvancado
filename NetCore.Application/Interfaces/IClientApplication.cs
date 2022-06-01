using NetCore.Application.DataContract.Request.Client;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IClientApplication
{
    Task<Response> CreateAsync(CreateClientRequest clientRequest);

    Task<Response> DeleteAsync(string clientId);

    Task<Response> GetByIdAsync(string clientId);
    //Task<Response<ClientModel>> GetByIdAsync(string clientId);

    Task<Response> GetListByFilterAsync(string clientId, string name);
    //Task<Response<List<ClientModel>>> GetListByFilterAsync(string clientId, string name);

    Task<Response> UpdateAsync(ClientModel client);
}