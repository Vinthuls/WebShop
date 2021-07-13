using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebShop.Models;

namespace WebShop.Pages.Users
{
    public class UserListModel : PageModel
    {
        public UserManager<IdentityUser> UserManager;
        public UserListModel(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public IEnumerable<IdentityUser> Users { get; set; }

        public void OnGet()
        {
            Users = UserManager.Users;
        }
    }
}
