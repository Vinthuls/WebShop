using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        private DataContext context;
        public NavBarViewComponent(DataContext dataContext)
        {
            context = dataContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(context.Products
                .Select(c => c.Category)
                .Distinct().OrderBy(c => c));
        }
    }
}
