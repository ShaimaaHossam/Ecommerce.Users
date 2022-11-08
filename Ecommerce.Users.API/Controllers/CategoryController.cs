using AutoMapper;
using Ecommerce.Users.Data.Models;
using Ecommerce.Users.Services.Categories;
using Ecommerce.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Users.API.Controllers
{
    [ApiController, Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService db;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CategoryViewModel>> GetCategories(bool deleted=false)
        {
            try
            {
                var categories = await db.GetAllCategoriesAsync(deleted);


                var actual = mapper.Map<IEnumerable<CategoryViewModel>>(categories);
                return Ok(actual);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetCategorybyId(int id)
        {
            try
            {
                var result = await db.GetCategoryByID(id);

                if (result == null)
                {
                    return NotFound();
                }
                var actual = mapper.Map<CategoryViewModel>(result);

                return Ok(actual);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryViewModel categoryVM)
        {
            try
            {
                if (categoryVM == null)
                {
                    return Ok("Hello");
                }

                var category = mapper.Map<Category>(categoryVM);

                await db.Add(category);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCategorybyId), new { id = category.Id },
                    category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            try
            {
                var categoryToDelete = await db.GetCategoryByID(id);

                if (categoryToDelete == null)
                {
                    return NotFound($"Category with Id = {id} not found");
                }

                var res =  await db.Delete(id);
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
        public async Task<ActionResult<Category>> UpdateEmployee(int id, CategoryViewModel categoryViewModel)
        {
            try
            {

                var categoryToUpdate = await db.GetCategoryByID(id);

                if (categoryToUpdate == null)
                {
                    return NotFound($"Category with Id = {id} not found");
                }

                var result =  await db.Update(id, categoryViewModel);
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
