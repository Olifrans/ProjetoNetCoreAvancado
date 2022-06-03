using NetCore.Domain.Models;


namespace NetCore.Domain.Interfaces.Repositories;
public interface IOrdersRepository
{
    Task CreateAsync(OrdersModel orders);

    Task CreateItemAsync(OrderItemModel item);

    Task UpdateAsync(OrdersModel orders);

    //Task UpdateItemAsync(OrderItemModel item);

    Task DeleteAsync(string ordersId);

    Task DeleteItemAsync(string itemId);

    Task<OrdersModel> GetByIdAsync(string ordersId);

    Task<List<OrdersModel>> GetListByFilterAsync(string ordersId = null, string clientId = null, string usersId = null);

    Task<List<OrderItemModel>> GetListByOrderIdAsync(string ordersId);

    Task<bool> ExistsByIdAsync(string ordersId);
}



