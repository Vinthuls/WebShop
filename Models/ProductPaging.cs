using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ProductPaging
    {
        public IEnumerable<Product> Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
