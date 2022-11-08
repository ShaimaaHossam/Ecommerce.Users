using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required, DataType(DataType.Text), MaxLength(20)]
        public string UserName { get; set; }
        [Required, DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; }
    }
}
