using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;
using ShopWPF.Enums;
using System.Windows.Input;
using ShopWPF.Commands;
using ShopWPF.Services;
using ShopWPF.ViewModels.Intefraces;

namespace ShopWPF.ViewModels.ProductsViewModels
{
    internal class ProductViewModel : ViewModelBase, ViewModelWithId
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

        public int Id => _product.ProductId;

        public ProductViewModel(ProductModel product)
        {
            _product = product;
            Category = _product.Category.Name;
            Price = _product.Price.ToString("N2");
        }
    }
}
