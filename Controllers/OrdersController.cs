using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Controllers
{
    public class OrdersController : Controller
    {
        public DataContext dataContext { get; set; }
        private UserManager<MyUser> userManager { get; set; }
        public OrdersController(DataContext dataContext, UserManager<MyUser> userManager)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            MyUser myUser = await userManager.GetUserAsync(HttpContext.User);
            IEnumerable<Order> orders = dataContext.Orders
                                                .Include(o => o.OrderAdress)
                                                .Include(o => o.OrderItems)
                                                .ThenInclude(oi => oi.Product)
                                                .Where(o => o.MyUserId == myUser.Id);

            return View("OrdersView", orders);
        }
    }
}
