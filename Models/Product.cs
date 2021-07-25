using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public IEnumerable<Theme> Themes { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
