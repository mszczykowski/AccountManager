using AccountManager.Discounts;
using AccountManager.Enums;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Services
{
    internal interface IDiscountsManagerService
    {
        public int AddCategoryDiscount(int discountType, Categories category);
        public int AddProductDiscount(int discountType, ProductModel product);
        public int AddOtherDiscount(int discountType);

        public void DeleteDiscount(int id);

        public void LoadDiscounts(DiscountManager discountManager, IProductsManagerService productManagerDatabaseService);
    }
}
