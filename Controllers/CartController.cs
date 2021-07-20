using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Extensions;
using WebShop.Models;
using Microsoft.AspNetCore.Http;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        public ShoppingCart ShoppingCart;
        public DataContext DataContext;
        
        public CartController(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public IActionResult Index()
        {
            ShoppingCart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            return View(ShoppingCart);
        }
        public async Task<IActionResult> Add(long id)
        {
            Product p = await DataContext.Products.FindAsync(id);
            var cart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            if(null == cart) 
            {

                ShoppingCart = new ShoppingCart();
                ShoppingCart.CartItems.Add(new CartItem { Product = p, Quantity = 1 });
                MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                ShoppingCart = cart;
            }
            for(int i = 0; i < ShoppingCart.CartItems.Count(); i++)
            {
                if (ShoppingCart.CartItems[i].Product.ProductId == p.ProductId)
                {
                    ShoppingCart.CartItems[i].Quantity++;
                    MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
                    return RedirectToAction(nameof(Index));
                }
            }
            ShoppingCart.CartItems.Add(new CartItem { Product = p, Quantity = 1 });
            MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
            return RedirectToAction(nameof(Index));
        }
    }
}
