using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;

namespace AccountManager.Discounts
{
    internal abstract class ProductDiscount : DiscountBase
    {
        protected ProductModel _discountedProduct;

        public ProductDiscount(ProductModel discountedProduct)
        {
            _discountedProduct = discountedProduct;
        }

        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);


    }
}
