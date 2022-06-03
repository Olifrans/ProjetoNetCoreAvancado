using NetCore.Application.DataContract.Request.Orders;
using NetCore.Application.DataContract.Response.Orders;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Interfaces;

public interface IOrdersApplication
{
    Task<Response> CreateAsync(CreateOrdersRequest ordersRequest);
    Task<Response<List<OrdersResponse>>> GetListByFilterAsync(string orderId = null, string clientId = null, string userId = null);
    Task<Response<OrdersResponse>> GetByIdAsync(string orderId);
}