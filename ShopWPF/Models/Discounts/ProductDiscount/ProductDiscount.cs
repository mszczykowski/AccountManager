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
        public ProductModel DiscountedProduct { get; set; }

        public ProductDiscount(int id, ProductModel discountedProduct) : base(id)
        {
            DiscountedProduct = discountedProduct;
        }

        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);


    }
}
