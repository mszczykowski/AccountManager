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
        public int Id { get; }
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
        public ICollection<OrderProductModel> Products { get; }

        public int CustomerId { get; }

        public OrderModel(int id, int customerId)
        {
            Id = id;

            CustomerId = customerId;

            Products = new List<OrderProductModel>();

            OrderDate = DateTime.Now;
        }

    }
}
