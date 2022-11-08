using Ecommerce.Users.Data.Models;
using Ecommerce.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(int pageSize, int pageNumber, bool deleted);
        Task<Product> GetProductById(int id);
        Task<Category> GetProductCategory(int id);
        Task<Product> Add(UpdateProductViewModel productVM);
        Task<Product> Update(int id, UpdateProductViewModel productViewModel);
        Task<Product> Delete(int id);
        Task<bool> SaveChangesAsync();
    }
}
