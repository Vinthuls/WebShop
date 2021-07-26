using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebShop.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        [Required][Display(Name = "Category name")]
        [MaxLength(20, ErrorMessage = "Category name must not exeed 20 characters."),]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
