using AutoMapper;
using Ecommerce.Users.Data.Models;
using Ecommerce.Users.Services.Categories;
using Ecommerce.Users.Services.Products;
using Ecommerce.Users.ViewModels;
using Ecommerce.Users.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Users.API.Controllers
{
    [ApiController, Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService db;
        private readonly IMapper mapper;

        public ProductController(IProductService db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<GetProductViewModel>> GetProducts(int pageSize=10, int pageNumber=1, bool deleted = false)
        {
            try
            {
                var products = await db.GetAllProductsAsync(pageSize, pageNumber, deleted);
                var actual = mapper.Map<IEnumerable<GetProductViewModel>>(products);
                return Ok(actual);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetProductById(int id)
        {
            try
            {
                var result = await db.GetProductById(id);

                if (result == null)
                {
                    return NotFound();
                }
                var actual = mapper.Map<GetProductViewModel>(result);

                return Ok(actual);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Category>> CreateProduct(UpdateProductViewModel productViewModel)
        {
            try
            {
                if (productViewModel == null)
                {
                    return BadRequest();
                }


                var result = await db.Add(productViewModel);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProductById), new { id = result.Id  },
                    result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = await db.GetProductById(id);

                if (productToDelete == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                var res = await db.Delete(id);
                await db.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateEmployee(int id, UpdateProductViewModel categoryViewModel)
        {
            try
            {

                var productToUpdate = await db.GetProductById(id);

                if (productToUpdate == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                var result = await db.Update(id, categoryViewModel);
                await db.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
