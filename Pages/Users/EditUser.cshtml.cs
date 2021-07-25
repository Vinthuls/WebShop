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
    public class EditUserModel : AdminPageModel
    {
        public UserManager<MyUser> UserManager;
        public EditUserModel(UserManager<MyUser> userManager)
        {
            UserManager = userManager;
        }

        [BindProperty][Required]
        public string Id { get; set; }

        [BindProperty] [Required]
        public string UserName { get; set; }

        [BindProperty][Required][EmailAddress]
        public string Email { get; set; }

        [BindProperty][Required]
        public string Password { get; set; }

        public async Task OnGetAsync(string id)
        {
            MyUser user = await UserManager.FindByIdAsync(id);
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                MyUser user = await UserManager.FindByIdAsync(Id);
                user.UserName = UserName;
                user.Email = Email;
                IdentityResult result =
                    await UserManager.UpdateAsync(user);

                if(result.Succeeded && !string.IsNullOrEmpty(Password))
                {
                    await UserManager.RemovePasswordAsync(user);
                    result = await UserManager.AddPasswordAsync(user, Password);
                }
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
