using AccountManager.Enums;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Services
{
    internal interface IShoppingCartDatabaseService
    {
        public void AddProductToCart(int userId, ProductModel product);

        public void DeleteProductFromCart(int userId, ProductModel product);

        public void UpdateProductQuantity(int userId, int productId, int newQuantity);

        public void ClearCart(int userId);

        public ICollection<ShoppingCartEntryModel> LoadCart(int userId, IProductsManagerService productsManagerService);
    }
}
