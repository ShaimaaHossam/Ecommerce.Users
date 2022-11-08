using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Users.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsImages = new HashSet<ProductsImage>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        [Required]

        public decimal Price { get; set; }
        [Required]

        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]

        public DateTime CreatedAt { get; set; }
        [Required]

        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductsImage> ProductsImages { get; set; }
    }
}
