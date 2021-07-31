using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.AspNetCore.Identity;
using WebShop.Extensions;

namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        private DataContext dataContext;
        private UserManager<MyUser> userManager;

        public CheckoutController(DataContext dataContext, UserManager<MyUser> userManager)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {

            return View("Checkout", MySessionExtensions.Get<ShoppingCart>(HttpContext.Session, "cart"));
        }
    }
}
