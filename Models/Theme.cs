using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Theme
    {
        public long ThemeId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
