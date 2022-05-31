using NetCore.Domain.Models;

namespace NetCore.Domain.Interfaces.Services;

public interface IOrdersService
{
    Task CreateAsync(OrdersModel orders);

    Task UpdateAsync(OrdersModel orders);

    Task DeleteAsync(string ordersId);

    Task<OrdersModel> GetByIdAsync(string ordersId);

    Task<List<OrdersModel>> GetListByFilterAsync(string ordersId = null, string clientId = null, string usersId = null);
}