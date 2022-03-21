using AccountManager.Context;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Services
{
    internal class ShoppingCartDatabaseService : IShoppingCartDatabaseService
    {
        private DatabaseConnection _databaseConnection;

        public ShoppingCartDatabaseService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public void AddProductToCart(int userId, ProductModel product)
        {
            string query = "insert into [UserCart] (UserId, ProductId, Quantity) "
                          + "values ('" + userId + "', '" + product.Id + "', '1');";

            _databaseConnection.ExecuteDML(query);
        }

        public void ClearCart(int userId)
        {
            string query = "delete from [UserCart] "
                            + "where userid = '" + userId + "'";

            _databaseConnection.ExecuteDML(query);
        }

        public void DeleteProductFromCart(int userId, ProductModel product)
        {
            string query = "delete from [UserCart] "
                               + "where userid = '" + userId + "' and productid = '" + product.Id + "';";


            _databaseConnection.ExecuteDML(query);
        }

        private void DeleteProductFromCart(int userId, int productId)
        {
            string query = "delete from [UserCart] "
                               + "where userid = '" + userId + "' and productid = '" + productId + "';";


            _databaseConnection.ExecuteDML(query);
        }

        public ICollection<ShoppingCartEntryModel> LoadCart(int userId, IProductsManagerService productsManagerService)
        {
            List<ShoppingCartEntryModel> shoppingCart = new List<ShoppingCartEntryModel>();
            
            string query = "select * " +
                            "from [UserCart]" +
                            "where userid = '" + userId + "';";

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            dbResult.ForEach(result =>
            {
                var product = productsManagerService.GetProduct(Convert.ToInt32(result[1]));

                if (product != null && product.Quantity > Convert.ToInt32(result[2]))
                {
                    shoppingCart.Add(new ShoppingCartEntryModel(product, Convert.ToInt32(result[2])));
                }
                else DeleteProductFromCart(userId, Convert.ToInt32(result[1]));
                
            });

            return shoppingCart;
        }

        public void UpdateProductQuantity(int userId, int productId, int newQuantity)
        {
            string query = "update [UserCart] " +
                            "set Quantity = '" + newQuantity + "' " +
                            "where userid = '" + userId + "' and productid = '" + productId + "';";

            _databaseConnection.ExecuteDML(query);
        }
    }
}
