using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;

namespace ShopWPF.Models.Discounts
{
    internal abstract class ProductDiscount : DiscountBaseModel
    {
        protected ProductModel _discountedProduct;

        public ProductDiscount(ProductModel discountedProduct)
        {
            _discountedProduct = discountedProduct;
        }

        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);


    }
}
