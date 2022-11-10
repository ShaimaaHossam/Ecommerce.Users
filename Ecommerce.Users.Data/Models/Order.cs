using Ecommerce.Users.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Users.Data.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;

        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
