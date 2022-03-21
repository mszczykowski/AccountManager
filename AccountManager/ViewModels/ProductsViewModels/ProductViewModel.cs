using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Services;

namespace AccountManager.ViewModels.ProductsViewModels
{
    internal class ProductViewModel : ViewModelBase
    {
        private ProductModel _product;

        public ProductModel Product 
        { 
            get => _product;
        }

        public string Name => _product.Name;
        public string Price { get; }
        public int Quantity => _product.Quantity;
        public string Category { get; }

        private bool _isChecked;
        public bool IsChecked 
        { 
            get => _isChecked; 
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public ProductViewModel(ProductModel product)
        {
            _product = product;
            Category = _product.Category.ToString();
            Price = _product.Price.ToString("N2");
        }
    }
}
