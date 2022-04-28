using AccountManager.Context;
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
    internal class DiscountDatabaseService : IDiscountsManagerService
    {
        private DatabaseConnection _databaseConnection;

        public DiscountDatabaseService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }


        public int AddCategoryDiscount(int discountType, Categories category)
        {
            string query = "insert into [Discount] (DiscountType, CategoryId) " +
                            "values ('" + (discountType + 1) + "', '" + ((int)category + 1) + "');";

            return _databaseConnection.ExecuteDML(query);
        }

        public int AddOtherDiscount(int discountType)
        {
            string query = "insert into [Discount] (DiscountType) " +
                            "values ('" + (discountType + 1) + "');";

            return _databaseConnection.ExecuteDML(query);
        }

        public int AddProductDiscount(int discountType, ProductModel product)
        {
            string query = "insert into [Discount] (DiscountType, ProductId) " +
                            "values ('" + (discountType + 1) + "', '" + product.Id + "');";

            return _databaseConnection.ExecuteDML(query);
        }

        public void DeleteDiscount(int id)
        {
            string query = "delete from [Discount] "
                + "where id = '" + id + "'";

            _databaseConnection.ExecuteDML(query);
        }

        public void LoadDiscounts(DiscountManager discountManager, IProductsManagerService productsManagerService)
        {
            string query = "select * from [Discount];";


            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            dbResult.ForEach(result =>
            {
                switch(Convert.ToInt32(result[1]) - 1)
                {
                    case (int)DiscountTypes.Product_discount:
                        var product = productsManagerService.GetProduct(Convert.ToInt32(result[3]));

                        if (product != null)
                        {
                            discountManager.AddDiscount(new ThirtyPercentOffProdcut(Convert.ToInt32(result[1]) - 1, product));
                        }
                        
                        break;
                    case (int)DiscountTypes.Category_discount:
                        discountManager.AddDiscount(new FiftyPercentOffOnCategorySecondProduct(Convert.ToInt32(result[1]) - 1,
                            (Categories)(Convert.ToInt32(result[2]) - 1)));
                        break;
                    case (int)DiscountTypes.Total_price_discount:
                        discountManager.AddDiscount(new TenEveryHundredDiscount(Convert.ToInt32(result[1]) - 1));
                        break;

                }
            });
        }
    }
}
