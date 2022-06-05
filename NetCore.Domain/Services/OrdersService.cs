using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Service;
using NetCore.Domain.Models;

namespace NetCore.Domain.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository ordersRepository;
    public OrdersService(IOrdersRepository ordersRepository)
    {
        this.ordersRepository = ordersRepository;
    }



    public Task CreateAsync(OrdersModel orders)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string ordersId)
    {
        throw new NotImplementedException();
    }

    public Task<OrdersModel> GetByIdAsync(string ordersId)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrdersModel>> GetListByFilterAsync(string ordersId = null, string clientId = null, string usersId = null)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrdersModel orders)
    {
        throw new NotImplementedException();
    }
}