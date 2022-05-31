using NetCore.Domain.Models;

namespace NetCore.Domain.Interfaces.Repositories;
public interface IProductRepository
{
    Task CreateAsync(ProductModel product);

    Task UpdateAsync(ProductModel product);

    Task DeleteAsync(string productId);

    Task<ProductModel> GetByIdAsync(string productId);

    Task<List<ProductModel>> GetListByFilterAsync(string productId = null, string description = null);

    Task<bool> ExistsByIdAsync(string productId);
}