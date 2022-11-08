using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Data.Models
{
    [Table("AppUsers")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(20), MinLength(3)]
        public string FirstName { get;set; }
        [Required, MaxLength(20), MinLength(3)]
        public string LastName { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required, DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
