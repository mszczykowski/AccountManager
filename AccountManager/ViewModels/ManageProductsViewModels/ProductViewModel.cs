using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;

namespace AccountManager.ViewModels
{
    internal class ProductViewModel : ViewModelBase
    {
        private ProductModel _product;
        public string Name => _product.Name;
        public double Price => _product.Price;
        public int Amount => _product.Amount;
        public string Category { get; }

        public ProductViewModel(ProductModel product)
        {
            _product = product;
            Category = _product.Category.ToString();
        }
    }
}
