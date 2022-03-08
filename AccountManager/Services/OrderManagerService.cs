using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Context;
using AccountManager.Enums;

namespace AccountManager.Services
{
    internal class OrderManagerService : IOrderManagerService
    {
        DataContext _dataContext;

        public OrderManagerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public OrderModel GetOrder(int id)
        {
            foreach (var order in _dataContext.Orders)
            {
                if (order.Id == id) return order;
            }

            return null;
        }

        public IEnumerable<OrderModel> GetUserOrders(int userId)
        {
            List<OrderModel> userOrders = new List<OrderModel>();

            foreach(var order in _dataContext.Orders)
            {
                if(order.CustomerId == userId) userOrders.Add(order);
            }

            return userOrders;
        }

        public void UpdateStatus(int orderId, OrderStatuses orderStatus)
        {
            var order = GetOrder(orderId);

            order.Status = orderStatus;
        }
    }
}
