using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class ShoppingCartEntryModel
    {
        private ProductModel _product;

        public ProductModel Product { get => _product; set => _product = value; }

        public int Quantity { get; set; }

        public ShoppingCartEntryModel(ProductModel product)
        {
            _product = product;
            Quantity = 1;
        }

        public override bool Equals(object? obj)
        {
            return obj is ShoppingCartEntryModel model &&
                   Product == model.Product;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Product);
        }
    }
}
