using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnSale { get; set; } = false;
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
