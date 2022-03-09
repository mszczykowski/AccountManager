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
        private DataContext _dataContext;
        private Random random;

        public OrderManagerService(DataContext dataContext)
        {
            _dataContext = dataContext;

            random = new Random();
        }

        public void AddOrder(OrderModel order)
        {
            order.Id = GenerateId();
            _dataContext.Orders.Add(order);
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
        

        private int GenerateId()
        {
            int id;

            bool isIdValid = true;
            do
            {
                id = random.Next();

                _dataContext.Products.ForEach(p =>
                {
                    if (p.Id == id) isIdValid = false;
                });
            }
            while (!isIdValid);

            return id;
        }
    }
}
