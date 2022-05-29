using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;
using ShopWPF.Enums;

namespace ShopWPF.Services.Interfaces
{
    internal interface IOrderManagerService
    {
        Task<IEnumerable<OrderModel>> GetUserOrders(int userId);

        Task<OrderModel> GetOrder(int id);

        Task UpdateStatus(int orderId, OrderStatuses orderStatus);

        Task AddOrder(OrderModel order);
    }
}
