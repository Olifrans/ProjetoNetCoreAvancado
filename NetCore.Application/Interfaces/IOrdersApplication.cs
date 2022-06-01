using NetCore.Application.DataContract.Request.Client;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IOrdersApplication
{


    Task CreateAsync(OrdersModel orders)
   
    Task DeleteAsync(string ordersId)
   

    Task<OrdersModel> GetByIdAsync(string ordersId)
    

    Task<List<OrdersModel>> GetListByFilterAsync(string ordersId = null, string clientId = null, string usersId = null)
    

    Task UpdateAsync(OrdersModel orders)
   

}