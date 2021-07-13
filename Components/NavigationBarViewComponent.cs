﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

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
            return View(context.Products
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c));
        }
    }
}