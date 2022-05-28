using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;
using ShopWPF.Enums;

namespace ShopWPF.Services
{
    internal interface IProductManagerService
    {
        Task<ICollection<ProductModel>> GetAllProducts();

        Task AddProduct(ProductModel product);

        Task EditProduct(int id, ProductModel product);

        Task<ProductModel> GetProduct(int id);

        Task DeleteProduct(int id);

        Task ChangeQuantity(int productId, int newQuantity);

        Task<ProductModel> GetProductIncludingDeleted(int id);
    }
}
