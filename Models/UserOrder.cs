using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Models
{
    public class UserOrder
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public string UserId { get; set; }
        public MyUser Id { get; set; }
    }
}
