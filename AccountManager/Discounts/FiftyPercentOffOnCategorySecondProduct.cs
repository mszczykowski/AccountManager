using AccountManager.Enums;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Discounts
{
    internal class FiftyPercentOffOnCategorySecondProduct : CategoryDiscount
    {
        public FiftyPercentOffOnCategorySecondProduct(int id, Categories category) : base(id, category)
        {

        }

        public override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart)
        {
            int i = 0;

            foreach (var shoppingCartEntry in shoppingCart)
            {
                if (shoppingCartEntry.Product.Category == _discountedCategory) i++;

                if (i == 2)
                {
                    return shoppingCartEntry.Product.Price * 0.5;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return "50% off on second product from " + _discountedCategory.ToString();
        }
    }
}
