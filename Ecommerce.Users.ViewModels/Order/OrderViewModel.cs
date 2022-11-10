using Ecommerce.Users.Data.Enums;
using Ecommerce.Users.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Users.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; }
        public decimal TotalPrice { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string AddressLine3 { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
