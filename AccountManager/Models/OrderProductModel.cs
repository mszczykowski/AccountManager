using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class OrderProductModel
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public OrderProductModel(int productId, double price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
    }
}
