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
        public CategoryModel DiscountedCategory { get; set; }

        public CategoryDiscount(int id, CategoryModel discountedCategory) : base(id)
        {
            DiscountedCategory = discountedCategory;
        }

        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
