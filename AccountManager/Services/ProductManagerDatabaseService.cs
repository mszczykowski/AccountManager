using AccountManager.Context;
using AccountManager.Enums;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Services
{
    internal class ProductManagerDatabaseService : IProductsManagerService
    {
        private DatabaseConnection _databaseConnection;

        public ProductManagerDatabaseService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }


        public void AddProduct(ProductModel product)
        {
            string query = "insert into [Product] (Name, Price, Quantity, IsDeleted, Category)"
                + "values ('" + product.Name + "', '" + product.Price + "', '" + product.Quantity + "', '0', '" +
                (int)product.Category + "');";

            _databaseConnection.ExecuteDML(query);
        }

        public void DeleteProduct(int id)
        {
            string query = "delete from [Product] "
                + "where id = '" + id + "';";

            _databaseConnection.ExecuteDML(query);
        }

        public void EditProduct(int id, ProductModel product)
        {
            string query = "update [Product] "
                         + "set name = '" + product.Name + "', price = '" + product.Price + "', quantity = '" + product.Quantity +
                            "', category = '" + (int)product.Category + "' "
                         + "where id = '" + id + "';";

            _databaseConnection.ExecuteDML(query);
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            string query = "select * "
                          + "from [Product];";

            return GetProductsList(query);
        }

        public ICollection<ProductModel> GetFilteredProducts(string? keyWord, Categories? category)
        {
            return GetProductsList(QueryBuilder(keyWord, category));
        }

        public ProductModel GetProduct(int id)
        {
            string query = "select * "
                          + "from [Product] "
                          + "where id = '" + id + "';";

            return GetProductsList(query)[0];
        }

        public void ReduceProductQantity(int id, int reduceBy)
        {
            string query = "update [Product] "
                         + "set quantity = quantity - " + reduceBy + " "
                         + "where id = '" + id + "'";

            _databaseConnection.ExecuteDML(query);
        }

        public ICollection<ProductModel> SearchProductByName(string keyWord)
        {
            string query = "select * "
                          + "from [Product]"
                          + "where upper(name) = '" + keyWord.ToUpper() + "';";

            return GetProductsList(query);
        }


        private ProductModel CreateProductModel(object[] row)
        {
            return new ProductModel(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToDouble(row[2]),
                Convert.ToInt32(row[3]), (Categories)Convert.ToInt32(row[5]) );
        }

        private List<ProductModel> GetProductsList(string query)
        {
            List<ProductModel> products = new List<ProductModel>();

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            dbResult.ForEach(result =>
            {
                products.Add(CreateProductModel(result));
            });

            return products;
        }

        private string QueryBuilder(string? keyWord, Categories? category)
        {
            string query = "select * "
                          + "from [Product] ";
            
            if (!string.IsNullOrEmpty(keyWord) || category != null) query += "where ";

            if (!string.IsNullOrEmpty(keyWord)) query += "upper(name) like " + "'%" + keyWord.ToUpper() + "%' ";

            if (!string.IsNullOrEmpty(keyWord) && category != null) query += "and ";

            if (category != null) query += "category = " + (int)category;

            query += ";";

            return query;
        }
    }
}
