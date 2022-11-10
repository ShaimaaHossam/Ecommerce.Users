using Ecommerce.Users.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services
{
    public class OrderService : IOrderService
    {
        private readonly EcommerceContext db;
        public OrderService(EcommerceContext db)
        {
            this.db = db;
        }
        public async Task AddOrder(string userID, Order order)
        {
            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;
            await db.Orders.AddAsync(order);
        }

        public async Task<Order> DeleteOrder(string userID, int id)
        {
            var result = await db.Orders.FirstOrDefaultAsync(p => p.Id == id && p.UserId == userID);
            if (result != null)
            {
                result.IsDeleted = true;
            }
            return null;
        }

        public async Task<Order> GetOrderById(string userID, int id)
        {
            var order = await db.Orders.Where(p => p.Id == id && p.UserId ==userID).Include(p => p.User).FirstOrDefaultAsync();
            if (order == null || order.IsDeleted)
                return null;

            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders(string userID)
        {
            return await db.Orders.Where(o => o.UserId == userID).ToListAsync() ;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await db.SaveChangesAsync() >= 0);
        }

        public async Task<Order> UpdateOrder(string userID, Order order)
        {
            var result = await db.Orders.Include(p => p.User)
           .FirstOrDefaultAsync(p => p.UserId == userID);

            if (result != null && !result.IsDeleted)
            {
                result.Status = order.Status;
                result.City = order.City;
                result.Country = order.Country;
                result.Street = order.Street;
                result.Address = order.Address;
                result.UpdatedAt = DateTime.Now;
                return result;
            }

            return null;
        }
    }
}
