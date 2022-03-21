using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Enums;
using AccountManager.Models;

namespace AccountManager.Discounts
{
    internal abstract class CategoryDiscount : DiscountBase
    {
        protected Categories _discountedCategory;

        public CategoryDiscount(int id, Categories category) : base(id)
        {
            _discountedCategory = category;
        }

        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
