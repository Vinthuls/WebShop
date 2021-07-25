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
    public class UserListModel : AdminPageModel
    {
        public UserManager<MyUser> UserManager;
        public UserListModel(UserManager<MyUser> userManager)
        {
            UserManager = userManager;
        }

        public IEnumerable<MyUser> Users { get; set; }

        public void OnGet()
        {
            Users = UserManager.Users;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            MyUser user = await UserManager.FindByIdAsync(id);
            if (user is not null)
            {
                await UserManager.DeleteAsync(user);
            }
            return RedirectToPage();
        }
    }
}
