using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Models
{
    public class ProductModel : EntityBase
    {
        public string? Description { get; set; }
        public string? SelValue { get; set; }
        public int Stock { get; set; }
    }
}
