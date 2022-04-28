using AccountManager.Context;
using AccountManager.Enums;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Services
{
    internal class OrderManagerDatabaseService : IOrderManagerService
    {
        private DatabaseConnection _databaseConnection;

        public OrderManagerDatabaseService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddOrder(OrderModel order)
        {
            string query;
            query = "insert into [Order] (CustomerId, OrderDate, Status, TotalPrice, DiscountValue) "
                + "values ('" + order.CustomerId + "', '" + order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', '" + (int)(OrderStatuses.New + 1) + "', '" + order.TotalPrice.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "', '" + order.DiscountValue.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "');";

            int orderId = _databaseConnection.ExecuteDML(query);


            order.Products.ToList().ForEach(p =>
            {
                string query = "insert into [OrderProduct] (ProductId, OrderId, Price, Quantity) "
                + "values ('" + p.ProductId + "','" + orderId + "', '" + 
                p.Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "', '" + p.Quantity + "');";

                _databaseConnection.ExecuteDML(query);
            });
        }

        public OrderModel GetOrder(int id)
        {
            string query = "select * " +
                            "from [Order] " +
                            "where OrderId = '" + id + "';";

            return GetOrdersList(query)[0];
        }

        public IEnumerable<OrderModel> GetUserOrders(int userId)
        {
            string query = "select * " +
                            "from [Order] " +
                            "where CustomerId = '" + userId + "';";

            return GetOrdersList(query);
        }

        public void UpdateStatus(int orderId, OrderStatuses orderStatus)
        {
            string query = "update [Order] "
                         + "set status = '" + (int)orderStatus + 1 + "' "
                         + "where id = '" + orderId + "';";

            _databaseConnection.ExecuteDML(query);
        }

        private OrderModel CreateOrderModel(object[] row)
        {
            return new OrderModel(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]),
                Convert.ToDateTime(row[2]), (OrderStatuses)(Convert.ToInt32(row[3]) - 1),
                Convert.ToDouble(row[4]), Convert.ToDouble(row[5]));
        }

        private OrderProductModel CreateOrderProductModel(object[] row)
        {
            return new OrderProductModel(Convert.ToInt32(row[0]), Convert.ToDouble(row[2]),
                Convert.ToInt32(row[3]));
        }

        private HashSet<OrderProductModel> GetOrderProducts(int orderId)
        {
            HashSet<OrderProductModel> products = new HashSet<OrderProductModel>();
            
            string query = "select *" +
                            "from [OrderProduct]" +
                            "where OrderId = '" + orderId + "';";

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            dbResult.ForEach(result =>
            {
                products.Add(CreateOrderProductModel(result));
            });

            return products;
        }

        private List<OrderModel> GetOrdersList(string query)
        {
            List<OrderModel> orders = new List<OrderModel>();

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            dbResult.ForEach(result =>
            {
                var order = CreateOrderModel(result);

                order.Products = GetOrderProducts(Convert.ToInt32(result[0]));

                orders.Add(order);
            });

            return orders;
        }
    }
}
