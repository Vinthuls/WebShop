using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class CheckoutViewModel
    {
        public OrderAdress OrderAdress { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string UserId { get; set; }
    }
}
