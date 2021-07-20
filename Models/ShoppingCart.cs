using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ShoppingCart
    {
        public int OrderId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
