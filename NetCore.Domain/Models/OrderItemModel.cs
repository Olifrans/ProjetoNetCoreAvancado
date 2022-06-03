namespace NetCore.Domain.Models
{
    public class OrderItemModel : EntityBase
    {
        public OrdersModel? Orders { get; set; }
        public ProductModel? Product { get; set; }
        public decimal SelValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}