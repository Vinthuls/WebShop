using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebShop.Models
{
    public class Supplier
    {
        [Key]
        public long SupplierId { get; set; }

        [Required][Display(Name = "Supplier name")]
        [MaxLength(20, ErrorMessage = "Supplier name must not exeed 20 characters."),]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required][Display(Name = "Supplier city")]
        [MaxLength(20, ErrorMessage = "Supplier city must not exeed 20 characters."),]
        [Column(TypeName = "varchar(20)")]
        public string City { get; set; }
        public IEnumerable<Product> Products { get; set; }


    }
}
