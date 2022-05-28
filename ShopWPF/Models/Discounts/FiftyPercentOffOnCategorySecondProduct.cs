﻿using ShopWPF.Enums;
using ShopWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Models.Discounts
{
    internal class FiftyPercentOffOnCategorySecondProduct : CategoryDiscount
    {
        public FiftyPercentOffOnCategorySecondProduct(CategoryModel discountedCategory) : base(discountedCategory)
        {
        }

        public override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart)
        {
            var categoryProducts = shoppingCart.Where(entry => entry.Product.CategoryId == _discountedCategory.CategoryId).ToList();

            if (categoryProducts.Count >= 2)
            {
                var minPrice = categoryProducts.Min(entry => entry.Product.Price);
                return minPrice * 0.5;
            }

            else return 0;
        }

        public override string ToString()
        {
            return "50% off on second product from " + _discountedCategory.Name;
        }
    }
}
