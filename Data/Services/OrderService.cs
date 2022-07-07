using eTutorials.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var order = await _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Course).Include(o => o.User).ToListAsync();

            if (userRole != "Admin")
            {
                order = order.Where(o => o.UserId == userId).ToList();
            }

            return order;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEeail)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEeail
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    CourseId = item.Course.Id,
                    OrderId = order.Id,
                    Price = item.Course.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
