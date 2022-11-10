using Ecommerce.Users.Data.Models;
using Ecommerce.Users.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Users.ViewModels.Order;

namespace Ecommerce.Users.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders(string userID);
        Task<Order> GetOrderById(string userID, int id);
        Task AddOrder(string userID, Order order);
        Task<Order> UpdateOrder(string userID, Order order);
        Task<Order> DeleteOrder(string userID, int id);
        Task<bool> SaveChangesAsync();
    }
}
