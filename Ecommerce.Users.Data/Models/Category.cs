using System;
using System.Collections.Generic;

namespace Ecommerce.Users.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            InversePcategory = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? PcategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category? Pcategory { get; set; }
        public virtual ICollection<Category> InversePcategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
