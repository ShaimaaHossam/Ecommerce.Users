using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Users.Data.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]

        public int CategoryId { get; set; }
        public int? OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Order? Order { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
