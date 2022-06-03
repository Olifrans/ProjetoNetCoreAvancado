using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Application.DataContract.Request.Orders
{
    public class CreateOrderItemRequest
    {
        public string? ProductId { get; set; }
        public string? SelValueId { get; set; }
        public int Quantity { get; set; }
    }
}
