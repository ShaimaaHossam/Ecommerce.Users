using System;
using System.Collections.Generic;

namespace Ecommerce.Users.Data.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
