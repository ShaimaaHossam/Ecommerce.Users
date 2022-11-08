using Ecommerce.Users.Data.Models;
using Ecommerce.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Users.Data.Models;
namespace Ecommerce.Users.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool deleted);
        Task<Category> GetCategoryByID(int id);
        Task<IEnumerable<Product>> GetProductsInCategory(int id);
        Task Add(Category category);
        Task<Category> Update(int id, CategoryViewModel categoryViewModel);
        Task<Category> Delete(int id);
        Task<bool> SaveChangesAsync();

    }
}
