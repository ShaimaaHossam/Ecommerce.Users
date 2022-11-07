using System;
using System.Collections.Generic;

namespace Ecommerce.Users.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsImages = new HashSet<ProductsImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductsImage> ProductsImages { get; set; }
    }
}
