using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public static class ProductViewModelFactory
    {
        public static ProductViewModel Read(Product p)
        {
            return new ProductViewModel {
                Product = p,
                ActionName = "Read",
                Color = "info",
                IsModifiable = false
            };
            
        }
    }
}
