using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebShop.Models;
namespace WebShop.Pages.Roles
{
    public class RoleEditorModel : AdminPageModel
    {
        public UserManager<MyUser> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
        public RoleEditorModel(UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IdentityRole Role { get; set; }
        public Task<IList<MyUser>> Members() 
            => UserManager.GetUsersInRoleAsync(Role.Name);
        public async Task<IEnumerable<MyUser>> NonMembers() 
            => UserManager.Users.ToList().Except(await Members());
        public async Task OnGetAsync(string id) 
        { 
            Role = await RoleManager.FindByIdAsync(id); 
        }
        public async Task<IActionResult> OnPostAsync(string userid, string rolename) 
        {
            Role = await RoleManager.FindByNameAsync(rolename);
            MyUser user = await UserManager.FindByIdAsync(userid);
            IdentityResult result; 

            if (await UserManager.IsInRoleAsync(user, rolename)) 
            {
                result = await UserManager.RemoveFromRoleAsync(user, rolename); 
            }
            else 
            {
                result = await UserManager.AddToRoleAsync(user, rolename); 
            } 
            if (result.Succeeded) 
            { 
                return RedirectToPage(); 
            }
            else 
            { 
                foreach (IdentityError err in result.Errors) 
                { 
                    ModelState.AddModelError("", err.Description);
                } 
                return Page(); 
            }
        }
            
    }
}
