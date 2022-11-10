using AutoMapper;
using Ecommerce.Users.Services;
using Ecommerce.Users.ViewModels.Order;
using Ecommerce.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Users.Data.Models;

namespace Ecommerce.Users.API.Controllers
{
    [ApiController, Route("api/orders")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService db;
        private readonly IMapper mapper;

        public OrderController(IOrderService db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<OrderViewModel>> GetOrders(string userId)
        {
            try
            {
                var orders = await db.GetOrders(userId);
                var actual = mapper.Map<IEnumerable<OrderViewModel>>(orders);

                return Ok(actual);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.ToString());
            }

        }
        [HttpGet("{userId}/{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrderById(string userId, int id)
        {
            try
            {
                var result = await db.GetOrderById(userId, id);

                if (result == null)
                {
                    return NotFound();
                }
                var actual = mapper.Map<OrderViewModel>(result);

                return Ok(actual);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost("{userId}")]
        public async Task<ActionResult<Category>> CreateOrder(string userId, OrderViewModel orderViewModel)
        {
            try
            {
                if (orderViewModel == null)
                {
                    return BadRequest("No order was provided");
                }

                var actual = mapper.Map<Order>(orderViewModel);
                await db.AddOrder(userId, actual);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetOrderById), new { id = actual.Id },
                    actual);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
