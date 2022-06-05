using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Response.Client;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IClientApplication
{
    Task<Response> CreateAsync(CreateClientRequest clientRequest);

     Task<Response> DeleteAsync(string clientId);

    Task<Response<ClientResponse>> GetByIdAsync(string clientId);

    Task<Response<List<ClientResponse>>> GetListByFilterAsync(string clientId, string name);
  
    Task<Response> UpdateAsync(UpdateClientRequest updateClientRequest);
}