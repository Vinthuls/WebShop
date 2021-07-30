using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebShop.Extensions;
using WebShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Add(long id, long themeId)
        {
            Product p =
                await DataContext.Products
                        .Where(p => p.ProductId == id)
                        .FirstOrDefaultAsync();
            Theme t =
                await DataContext.Themes
                        .Where(t => t.ThemeId == themeId)
                        .FirstOrDefaultAsync();

            foreach(Theme theme in p.Themes)
            {
                theme.Product = null;
            }

            ShoppingCart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            if(null == ShoppingCart) 
            {
                ShoppingCart = new ShoppingCart();
                ShoppingCart.CartItems.Add(new CartItem { Product = p, Theme = t, Quantity = 1 });
                MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
                return View("~/Views/Cart/Index.cshtml", ShoppingCart);
            }
            else 
            {
                if (checkIfExists(p.ProductId, t.ThemeId, out int index))
                {
                    ShoppingCart.CartItems[index].Quantity++;
                }
                else
                {
                    ShoppingCart.CartItems.Add(
                        new CartItem { Product = p, Theme = t, Quantity = 1 });
                }
                MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
                return View("~/Views/Cart/Index.cshtml", ShoppingCart);
            }
        }

        public IActionResult Remove(long id, long themeId)
        {
            ShoppingCart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            if (checkIfExists(id, themeId, out int index) 
                && ShoppingCart.CartItems[index].Quantity > 1)
            {
                ShoppingCart.CartItems[index].Quantity--;
            }
            else
            {
                ShoppingCart.CartItems.RemoveAll(ci => ci.Product.ProductId == id 
                                                    && ci.Theme.ThemeId == themeId);
            }

            MySessionExtensions.Set(HttpContext.Session, "cart", ShoppingCart);
            return View("~/Views/Cart/Index.cshtml", ShoppingCart);
        }
        
        private bool checkIfExists(long id, long themeId, out int index)
        {
            for (int i = 0; i < ShoppingCart.CartItems.Count(); i++)
            {
                if(ShoppingCart.CartItems[i].Product.ProductId ==  id
                    && ShoppingCart.CartItems[i].Theme.ThemeId == themeId)
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
