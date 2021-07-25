using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Size
    {
        public long SizeId { get; set; }
        public long SizeNumber { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
