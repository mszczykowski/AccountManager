using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Enums;
using ShopWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class OrderManagerService : IOrderManagerService
    {
        private readonly ShopDBContext _context;

        public OrderManagerService(ShopDBContext context)
        {
            _context = context;
        }

        public async Task AddOrder(OrderModel order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == id);
        }

        public async Task<IEnumerable<OrderModel>> GetUserOrders(int userId)
        {
            return await _context.Orders.Where(order => order.CustomerId == userId).ToListAsync();
        }

        public async Task UpdateStatus(int orderId, OrderStatuses orderStatus)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == orderId);
            order.StatusId = (int)orderStatus;
            await _context.SaveChangesAsync();
        }
    }
}
