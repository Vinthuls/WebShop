using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using WebShop.Models;

namespace WebShop.Pages.Users
{
    public class CreateUserModel : AdminPageModel
    {
        public UserManager<MyUser> UserManager { get; set; }
        public CreateUserModel(UserManager<MyUser> userManager)
        {
            UserManager = userManager;
        }

        [BindProperty][Required]
        public string UserName { get; set; }

        [BindProperty][Required][EmailAddress]
        public string Email { get; set; }

        [BindProperty][Required]
        public string Password { get; set; }
        
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                MyUser user =
                    new MyUser { UserName = UserName, Email = Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, Password);
                if(result.Succeeded)
                {
                    return RedirectToPage("UserList");
                }
                foreach(IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Page();
        }
    }
}