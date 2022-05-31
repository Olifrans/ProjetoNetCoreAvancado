using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;

namespace NetCore.Domain.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }


    public Task CreateAsync(ProductModel product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductModel> GetByIdAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductModel>> GetListByFilterAsync(string productId = null, string description = null)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductModel product)
    {
        throw new NotImplementedException();
    }
}