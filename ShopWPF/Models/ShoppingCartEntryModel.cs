using System;

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

        public ShoppingCartEntryModel()
        {

        }

        public ShoppingCartEntryModel(ProductModel product)
        {
            Product = product;
            Quantity = 1;
        }

        public ShoppingCartEntryModel(ProductModel product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override bool Equals(object? obj)
        {
            return obj is ShoppingCartEntryModel model &&
                   ProductId == model.ProductId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId);
        }
    }
}
