using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Enums;

namespace ShopWPF.Models
{
    internal class OrderModel
    {
        [Key]
        public int OrderId { get; set;  }
        public DateTime OrderDate { get; }
        public double TotalPrice { get; set; }
        public double DiscountValue { get; set; }

        public int StatusId { get; set; }
        private OrderStatusModel _status;
        public OrderStatusModel Status 
        { 
            get => _status; 
            set
            {
                _status = value;
                StatusId = _status.Id;
            }
        }


        public int CustomerId { get; set; }
        private UserModel _customer;
        public UserModel Customer 
        { 
            get => _customer; 
            set
            {
                _customer = value;
                CustomerId = _customer.UserId;
            }
        }


        private HashSet<OrderProductModel> _products;
        public ICollection<OrderProductModel> Products
        {
            get => _products;
            set => _products = (HashSet<OrderProductModel>)value;
        }

        [NotMapped]
        public string Name
        {
            get => "Order_" + OrderId;
        }

        public OrderModel(int customerId, double totalPrice, double discountValue)
        {
            CustomerId = customerId;

            _products = new HashSet<OrderProductModel>();

            TotalPrice = totalPrice;

            DiscountValue = discountValue;

            OrderDate = DateTime.Now;
        }

        public OrderModel(int id, int customerId, DateTime orderDate, int statusId, 
            double totalPrice, double discountValue)
        {
            OrderId = id;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            DiscountValue = discountValue;
            StatusId = statusId;
            CustomerId = customerId;

            _products = new HashSet<OrderProductModel>();
        }

        public void AddProduct(OrderProductModel orderProductModel)
        {
            _products.Add(orderProductModel);
        }

    }
}
