using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Shared
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool isSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpiredDate { get; set; }

    }
}
