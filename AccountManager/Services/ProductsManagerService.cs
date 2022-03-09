using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Context;
using AccountManager.Enums;

namespace AccountManager.Services
{
    internal class ProductsManagerService : IProductsManagerService
    {
        private DataContext _context;
        private Random random;

        public ProductsManagerService(DataContext context)
        {
            _context = context;

            random = new Random();
        }

        public void AddProduct(ProductModel product)
        {
            product.Id = GenerateId();

            _context.Products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            _context.Products.Remove(GetProduct(id));
        }

        public void EditProduct(int id, ProductModel product)
        {
            var p = GetProduct(id);

            p.CopyData(product);
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            return _context.Products;
        }

        public ICollection<ProductModel> GetFilteredProducts(string? query, Categories? category)
        {
            ICollection<ProductModel> filteredByCategory = new List<ProductModel>();

            ICollection<ProductModel> filteredByQuery = new List<ProductModel>();

            if (category != null)
            {
                foreach (var product in _context.Products)
                {
                    if (product.Category == category) filteredByCategory.Add(product);
                }
            }
            else filteredByCategory = GetAllProducts();

            if (!String.IsNullOrEmpty(query))
            {
                foreach (var product in filteredByCategory)
                {
                    if (product.Name.ToUpper().Contains(query.ToUpper())) filteredByQuery.Add(product);
                }
            }
            else filteredByQuery = filteredByCategory;

            return filteredByQuery;
        }

        public ProductModel GetProduct(int id)
        {
            return _context.Products.Find(x => x.Id == id);
        }

        public void ReduceProductQantity(int productId, int reduceBy)
        {
            var product = GetProduct(productId);
            product.Quantity -= reduceBy;
        }

        public ICollection<ProductModel> SearchProductByName(string query)
        {
            List<ProductModel> products = new List<ProductModel>();

            foreach(var p in _context.Products)
            {
                if (p.Name.ToLower().Contains(query.ToLower())) products.Add(p);
            }

            return products;
        }

        private int GenerateId()
        {
            int id;

            bool isIdValid = true;
            do
            {
                id = random.Next();

                _context.Products.ForEach(p =>
                {
                    if (p.Id == id) isIdValid = false;
                });
            }
            while (!isIdValid);

            return id;
        }
    }
}
