namespace NetCore.Application.DataContract.Response.Orders;

public sealed class OrdersResponse
{
    public string? Id { get; set; }


    public ClientModel Client { get; set; }
    public UsersModel Users { get; set; }
    public List<OrderItemModel> Items { get; set; }


    public OrdersModel Orders { get; set; }
    public ProductModel Product { get; set; }
    public decimal SelValue { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
}