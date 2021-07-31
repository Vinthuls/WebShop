using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class OrderAdress
    {
        [Key]
        public long OrderAdressId { get; set; }

        [Required(ErrorMessage = "Name field is Required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is Required")]
        [Column(TypeName = "varchar(50)")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email Adress field is Required")]
        [EmailAddress][Display(Name = "Email Adress")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adress field is Required")]
        [Column(TypeName = "varchar(50)")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Country field is Required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State field is Required")]
        [Column(TypeName = "varchar(50)")]
        public string State { get; set; }

        [Required(ErrorMessage = "City field is Required")]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip Code field is Required")][Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string ZipCode { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
