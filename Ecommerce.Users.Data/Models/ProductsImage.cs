using System;
using System.Collections.Generic;

namespace Ecommerce.Users.Data.Models
{
    public partial class ProductsImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
