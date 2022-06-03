namespace NetCore.Application.DataContract.Response.Orders
{
    public class OrderItemResponse
    {
        public string? ProductId { get; set; }
        public string? SelValueId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}