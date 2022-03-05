using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Context;

namespace AccountManager.Services
{
    internal class ProductManagerService : IProductManagerService
    {
        DataContext _context;

        public ProductManagerService(DataContext context)
        {
            _context = context;
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            return _context.Products;
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
    }
}
