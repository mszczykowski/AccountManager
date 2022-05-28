using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Models
{
    internal class ShoppingCartEntryModel
    {
        public int? CustomerId { get; set; }

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

        public int ProductId { get; set; }

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

        public int Quantity { get; set; }

        public ShoppingCartEntryModel(ProductModel product)
        {
            _product = product;
            Quantity = 1;
        }

        public ShoppingCartEntryModel(ProductModel product, int quantity)
        {
            _product = product;
            Quantity = quantity;
        }
    }
}
