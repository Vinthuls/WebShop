using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Controllers
{
    public class Checkout : Controller
    {
        private DataContext dataContext { get; set; }
        private UserManager<MyUser> userManager { get; set; }

        public Checkout(DataContext dataContext, UserManager<MyUser> userManager)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
