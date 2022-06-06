using NetCore.Application.DataContract.Response.Client;
using NetCore.Application.DataContract.Response.Users;

namespace NetCore.Application.DataContract.Response.Orders;

public sealed class OrdersResponse
{
    public string ClientId { get; set; }
    public string UsersId { get; set; }
    public List<OrderItemResponse> Items { get; set; }
}