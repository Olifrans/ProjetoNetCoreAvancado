namespace NetCore.Application.DataContract.Response.Orders
{
    public class OrderItemResponse
    {
        public string? ProductId { get; set; }
        public decimal SelValueId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}