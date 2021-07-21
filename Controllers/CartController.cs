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
        public DataContext DataContext;
        
        public CartController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public ShoppingCart ShoppingCart;

        public IActionResult Index()
        {
            ShoppingCart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            return View(ShoppingCart);
        }
        public async Task<IActionResult> Add(long id)
        {
            Product p = await DataContext.Products.FindAsync(id);
            ShoppingCart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            if(null == ShoppingCart) 
            {
                ShoppingCart = new ShoppingCart();
                ShoppingCart.CartItems.Add(new CartItem { Product = p, Quantity = 1 });
                MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
                return View("~/Views/Cart/Index.cshtml", ShoppingCart);
            }
            else 
            {
                if (checkIfExists(p.ProductId, out int index))
                {
                    ShoppingCart.CartItems[index].Quantity++;
                }
                else
                {
                    ShoppingCart.CartItems.Add(new CartItem { Product = p, Quantity = 1 });
                }
                MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
                return View("~/Views/Cart/Index.cshtml", ShoppingCart);
            }
        }

        public IActionResult Remove(long id)
        {
            ShoppingCart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            if (checkIfExists(id, out int index) && ShoppingCart.CartItems[index].Quantity > 1)
            {
                ShoppingCart.CartItems[index].Quantity--;
            }
            else
            {
                ShoppingCart.CartItems.RemoveAll(ci => ci.Product.ProductId == id);
            }

            MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
            return View("~/Views/Cart/Index.cshtml", ShoppingCart);
        }
        
        private bool checkIfExists(long id, out int index)
        {
            for (int i = 0; i < ShoppingCart.CartItems.Count(); i++)
            {
                if(ShoppingCart.CartItems[i].Product.ProductId ==  id)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}
