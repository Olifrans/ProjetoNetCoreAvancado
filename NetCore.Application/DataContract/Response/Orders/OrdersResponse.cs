namespace NetCore.Application.DataContract.Response.Orders;

public sealed class OrdersResponse
{
    public string? Id { get; set; }

    public string? ClientId { get; set; }
    public string? UsersId { get; set; }
    public List<OrderItemResponse>? Items { get; set; }
}