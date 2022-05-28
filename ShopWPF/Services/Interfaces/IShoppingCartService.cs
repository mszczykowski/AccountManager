using ShopWPF.Enums;
using ShopWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Services
{
    internal interface IShoppingCartService
    {
        Task AddProductToCart(int userId, ProductModel product);

        Task DeleteProductFromCart(int userId, ProductModel product);

        Task UpdateProductQuantity(int userId, int productId, int newQuantity);

        Task ClearCart(int userId);

        Task<ICollection<ShoppingCartEntryModel>> LoadCart(int userId);
    }
}
