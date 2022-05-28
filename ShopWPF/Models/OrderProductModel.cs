using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Models
{
    internal class OrderProductModel
    {
        [Key]
        public int OrderProductId { get; set; }

        public int? ProductId { get; set; }

        private ProductModel _product;
        public ProductModel Product 
        { 
            get => _product; 
            set
            {
                _product = value;
                ProductId = _product.ProductId;
            }
        }

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
