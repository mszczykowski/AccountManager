using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;

namespace AccountManager.Services
{
    internal interface IProductManagerService
    {
        public ICollection<ProductModel> GetAllProducts();
        public ICollection<ProductModel> SearchProductByName(string query);
    }
}
