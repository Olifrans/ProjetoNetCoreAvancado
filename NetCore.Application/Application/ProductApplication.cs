using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Application;

public class ProductApplication : IProductApplication
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductApplication(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
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