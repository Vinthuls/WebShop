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
        public string Color { get; set; }
        public bool IsModifiable { get; set; } = false;
    }
}
