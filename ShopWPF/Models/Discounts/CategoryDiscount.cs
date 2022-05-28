using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Enums;
using ShopWPF.Models;

namespace ShopWPF.Models.Discounts
{
    internal abstract class CategoryDiscount : DiscountBaseModel
    {
        protected CategoryModel _discountedCategory;

        public CategoryDiscount(CategoryModel discountedCategory)
        {
            _discountedCategory = discountedCategory;
        }

        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
