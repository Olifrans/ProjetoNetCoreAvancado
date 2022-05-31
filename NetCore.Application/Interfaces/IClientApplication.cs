using NetCore.Application.DataContract.Request.Client;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IClientApplication
{
    Task<Response> CreateAsync(CreateClientRequest clientRequest);
}