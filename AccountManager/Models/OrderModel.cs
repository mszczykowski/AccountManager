using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Enums;

namespace AccountManager.Models
{
    internal class OrderModel
    {
        public int Id { get; set;  }
        public DateTime OrderDate { get; }
        public double TotalPrice { get; set; }
        public double DiscountValue { get; set; }
        public OrderStatuses Status { get; set; }

        private HashSet<OrderProductModel> _products;
        public ICollection<OrderProductModel> Products { get => _products; 
            set => _products = (HashSet<OrderProductModel>)value; }

        public int CustomerId { get; }

        public string Name
        {
            get => "Order_" + Id;
        }

        public OrderModel(int customerId, double totalPrice, double discountValue)
        {
            CustomerId = customerId;

            _products = new HashSet<OrderProductModel>();

            TotalPrice = totalPrice;

            DiscountValue = discountValue;

            OrderDate = DateTime.Now;
        }

        public OrderModel(int id, int customerId, DateTime orderDate, OrderStatuses status, 
            double totalPrice, double discountValue)
        {
            Id = id;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            DiscountValue = discountValue;
            Status = status;
            CustomerId = customerId;

            _products = new HashSet<OrderProductModel>();
        }

        public void AddProduct(OrderProductModel orderProductModel)
        {
            _products.Add(orderProductModel);
        }

    }
}
