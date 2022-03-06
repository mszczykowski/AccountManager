using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;

namespace AccountManager.Services
{
    internal interface IProductsManagerService
    {
        public ICollection<ProductModel> GetAllProducts();
        public ICollection<ProductModel> SearchProductByName(string query);
        public void AddProduct(ProductModel product);

        public void EditProduct(int id, ProductModel product);

        public ProductModel GetProduct(int id);

        public void DeleteProduct(int id);

        public ICollection<ProductModel> GetFilteredProducts(string? query, Categories? category);
    }
}
