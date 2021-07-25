using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace WebShop.Models
{
    public class MyUser : IdentityUser
    {
        public IEnumerable<UserOrder> UserOrders { get; set; }
    }
}
