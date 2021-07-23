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
        public NavigationBarViewComponent(DataContext dataContext)
        {
            context = dataContext;
        }

        public IViewComponentResult Invoke()
        {
            ShoppingCart cart = MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart");
            int itemsCount = 0;
            string totalPrice = "";
            if (null != cart)
            {
                itemsCount = cart.CartItems.Sum(ci => ci.Quantity);
                totalPrice = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity).ToString("c");
            }
            else
            {
                itemsCount = 0;
                totalPrice = "";
            }
            ViewBag.itemsCount = itemsCount;
            ViewBag.totalPrice = totalPrice;

            return View(context.Products
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c));
        }
    }
}
