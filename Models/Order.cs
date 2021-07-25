using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace WebShop.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public long TotalPrice { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
