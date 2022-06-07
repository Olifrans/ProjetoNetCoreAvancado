using NetCore.Application.DataContract.Request.Client;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IProductApplication
{

    Task CreateAsync(ProductModel product);

    Task DeleteAsync(string productId);

    Task<ProductModel> GetByIdAsync(string productId);

    Task<List<ProductModel>> GetListByFilterAsync(string productId = null, string description = null);

    Task UpdateAsync(ProductModel product);
}