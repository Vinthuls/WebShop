using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Extensions;
using Microsoft.AspNetCore.Http;
namespace WebShop.Components
{
    public class NavigationBarViewComponent : ViewComponent
    {
        private DataContext context;
        private ShoppingCart shoppingCart;
        public NavigationBarViewComponent(DataContext dataContext, ShoppingCart cart)
        {
            context = dataContext;
            shoppingCart = cart;
        }

        public IViewComponentResult Invoke()
        {
            
            ViewBag.itemsCount = shoppingCart.CartItems.Sum(ci => ci.Quantity);
            ViewBag.totalPrice = shoppingCart.CartItems.Sum(ci => 
                ci.Product.Price * ci.Quantity).ToString("c");
            ViewBag.isLogged = User.Identity.IsAuthenticated;

            return View(context.Categories
                .Distinct()
                .OrderBy(c => c));
        }
    }
}
