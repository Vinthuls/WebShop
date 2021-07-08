using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Controllers
{
    public class FormController : Controller 
    {
        private DataContext _dataContext;
        public FormController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        /*public IActionResult Create { }
        public IActionResult Read() { }
        public IActionResult Update() { }
        public IActionResult Delete() { }*/
    }
}
