using AutoMapper;
using Ecommerce.Users.Data.Models;
using Ecommerce.Users.Services.Categories;
using Ecommerce.Users.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Users.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommerceContext db;
        public CategoryService(EcommerceContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool deleted)
        {
            return await db.Categories.Where(c => c.IsDeleted == deleted).ToListAsync();
              
        }

        public async Task<Category> GetCategoryByID(int id)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null || category.IsDeleted)
                return null;

            return category;
        }

        public async Task<IEnumerable<Product>> GetProductsInCategory(int id)
        {
            var products = await db.Products.Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }

        public async Task Add(Category category)
        {
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            await db.Categories.AddAsync(category);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await db.SaveChangesAsync() >= 0);
        }

        public async Task<Category> Update(int id, CategoryViewModel categoryViewModel)
        {
            var result = await db.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryViewModel.Id);

            if(result != null && !result.IsDeleted)
            {
                result.Name = categoryViewModel.Name;
                result.UpdatedAt = DateTime.Now;
                return result;
            }

            return null;
        }
        public async Task<Category> Delete(int id)
        {
            var result = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(result != null)
            {
                result.IsDeleted = true;
            }
            return null;
        }

    }
}
