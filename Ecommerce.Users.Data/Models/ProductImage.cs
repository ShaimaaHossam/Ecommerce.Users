using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Users.Data.Models
{
    [Table("Image")]
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
