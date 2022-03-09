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
        public double TotalPrice 
        {
            get
            {
                double totalPrice = 0;

                foreach (var p in Products)
                {
                    totalPrice += p.Price * p.Quantity;
                }

                return totalPrice;
            }
        }
        public OrderStatuses Status { get; set; }

        private HashSet<OrderProductModel> _products;
        public ICollection<OrderProductModel> Products { get => _products; }

        public int CustomerId { get; }

        public OrderModel(int customerId)
        {
            CustomerId = customerId;

            _products = new HashSet<OrderProductModel>();

            OrderDate = DateTime.Now;
        }

        public void AddProduct(OrderProductModel orderProductModel)
        {
            _products.Add(orderProductModel);
        }

    }
}
