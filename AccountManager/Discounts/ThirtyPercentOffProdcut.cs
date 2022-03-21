using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Discounts
{
    internal class ThirtyPercentOffProdcut : ProductDiscount
    {
        public ThirtyPercentOffProdcut(int id, ProductModel discountedProduct) : base(id, discountedProduct)
        {

        }

        public override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart)
        {
            double discount = 0;

            shoppingCart.ToList().ForEach(shoppingCartItem =>
            {
                if (shoppingCartItem.Product.Equals(_discountedProduct)) discount += shoppingCartItem.Product.Price * shoppingCartItem.Quantity * 0.3;
            });

            return discount;
        }

        public override string ToString()
        {
            return "30% off " + _discountedProduct.Name;
        }
    }
}
