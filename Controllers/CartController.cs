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
        public ShoppingCart shoppingCart;

        public CartController(DataContext dataContext, ShoppingCart cart)
        {
            DataContext = dataContext;
            shoppingCart = cart;
        }

        public IActionResult Index()
        {
            return View(shoppingCart);
        }
        public async Task<IActionResult> Add(long id, long themeId)
        {
            CartItem item = shoppingCart.CartItems
                            .FindAll(ci =>
                                ci.Product.ProductId == id &&
                                ci.Theme.ThemeId == themeId).FirstOrDefault();
            if(item is null)
            {
                Product p =
                await DataContext.Products
                        .Include(p => p.Supplier)
                        .Where(p => p.ProductId == id)
                        .FirstOrDefaultAsync();
                Theme t =
                    await DataContext.Themes
                            .Where(t => t.ThemeId == themeId)
                            .FirstOrDefaultAsync();

                p.Themes = null;
                p.Supplier.Products = null;

                shoppingCart.CartItems.Add(new CartItem() 
                { 
                    Product = p, 
                    Theme = t, 
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }
            shoppingCart.SetShoppingCart("cart", shoppingCart);
            return View("~/Views/Cart/Index.cshtml", shoppingCart);
            
        }

        public IActionResult Remove(long id, long themeId)
        {
            CartItem item = shoppingCart.CartItems
                            .FindAll(ci =>
                                ci.Product.ProductId == id &&
                                ci.Theme.ThemeId == themeId).FirstOrDefault();

            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                shoppingCart.CartItems.RemoveAll(ci => ci.Product.ProductId == id 
                                                    && ci.Theme.ThemeId == themeId);
            }
            shoppingCart.SetShoppingCart("cart", shoppingCart);
            return View("~/Views/Cart/Index.cshtml", shoppingCart);
        }
    }
}
