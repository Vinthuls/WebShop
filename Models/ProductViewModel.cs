using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public string ActionName { get; set; }
        public string ThemeColor { get; set; }
        public bool IsReadOnly { get; set; } = false;
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
        public IEnumerable<Supplier> Suppliers { get; set; } = Enumerable.Empty<Supplier>();
    }
}
