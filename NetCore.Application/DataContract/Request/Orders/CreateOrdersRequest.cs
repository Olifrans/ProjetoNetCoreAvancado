using NetCore.Application.DataContract.Response.Orders;

namespace NetCore.Application.DataContract.Request.Orders;

public sealed class CreateOrdersRequest
{
    public string? ClientId { get; set; }
    public string? UsersId { get; set; }
    public List<OrderItemResponse>? Items { get; set; }
}