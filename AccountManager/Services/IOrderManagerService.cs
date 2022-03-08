using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;

namespace AccountManager.Services
{
    internal interface IOrderManagerService
    {
        public IEnumerable<OrderModel> GetUserOrders(int userId);

        public OrderModel GetOrder(int id);

        public void UpdateStatus(int orderId, OrderStatuses orderStatuses);
    }
}
