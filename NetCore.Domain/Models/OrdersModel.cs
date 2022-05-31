namespace NetCore.Domain.Models;

public class OrdersModel : EntityBase
{
    public ClientModel Client { get; set; }
    public UsersModel Users { get; set; }
    public List<OrderItemModel> Items { get; set; }
}