using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using WebShop.Extensions;

namespace WebShop.Models
{
    public class ShoppingCart
    {
        public Guid OrderId { get; } = new Guid();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            ShoppingCart cart = MySessionExtensions.Get<ShoppingCart>(session, "cart") ?? new ShoppingCart();
            cart.Session = session;
            return cart;
        }
        
        [JsonIgnore]
        ISession Session { get; set; }
        public void SetShoppingCart(string key, ShoppingCart cart)
        {
            MySessionExtensions.Set(Session, key, cart);
        }

        public void ClearShoppingCart()
        {
            CartItems.Clear();
            Session.Remove("cart");
        }

    }

    public class CartItem
    {
        public Product Product { get; set; }
        public Theme Theme { get; set; }
        public int Quantity { get; set; }
    }
}
