using Ecommerce.Users.Data.Models;
using Ecommerce.Users.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly EcommerceContext db;

        public ProductService(EcommerceContext db)
        {
            this.db = db;
        }
        public async Task<Product> Add(UpdateProductViewModel productVM)
        {
            var product = new Product()
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price,
                Quantity = productVM.Quantity,
                CategoryId = productVM.CategoryId,
                Category = productVM.Category,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await db.Products.AddAsync(product);
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var result = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                result.IsDeleted = true;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(int pageSize, int pageNumber, bool deleted)
        {
            return await db.Products.Where(p => p.IsDeleted == deleted)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null || product.IsDeleted)
                return null;

            return product;
        }

        public async Task<Category> GetProductCategory(int id)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            var category = await db.Categories.FirstOrDefaultAsync(c => c.Id == product.CategoryId);
            if (category == null || category.IsDeleted)
                return null;

            return category;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await db.SaveChangesAsync() >= 0);
        }
        public async Task<Product> Update(int id, UpdateProductViewModel productViewModel)
        {
            var result = await db.Products
            .FirstOrDefaultAsync(p => p.Id == id);

            if (result != null && !result.IsDeleted)
            {
                result.Name = productViewModel.Name;
                result.Description = productViewModel.Description;
                result.CategoryId = productViewModel.CategoryId;
                result.UpdatedAt = DateTime.Now;
                result.Price = productViewModel.Price;
                result.Quantity = productViewModel.Quantity;
                return result;
            }

            return null;
        }
    }
}
