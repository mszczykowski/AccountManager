using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.ShopViewModels
{
    internal class ShoppingCartEntryViewModel : ViewModelBase
    {
        private readonly ProductModel _productModel;
        private readonly ShoppingCartEntryModel _shoppingCartEntry;

        public ProductModel ProductModel => _productModel;

        public string Name => _productModel.Name;

        public string Price => _productModel.Price.ToString("N2");

        public int ActualQuantity 
        {
            get => _shoppingCartEntry.Quantity;
            set
            {
                _shoppingCartEntry.Quantity = value;
                OnPropertyChanged(nameof(ActualQuantity));
            }
        }

        public int MaximumQuantity => _productModel.Quantity;

        public string Category => _productModel.Category.ToString();

        private string _totalPrice;

        public string TotalPrice 
        {
            get => _totalPrice; 
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ShoppingCartEntryViewModel(ProductModel productModel, ShoppingCartEntryModel shoppingCartEntry)
        {
            _productModel = productModel;
            _shoppingCartEntry = shoppingCartEntry;

            UpdateTotalPrice();

            this.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShoppingCartEntryViewModel.ActualQuantity)) UpdateTotalPrice();
        }

        public void UpdateTotalPrice()
        {
            if (_shoppingCartEntry.Quantity > _productModel.Quantity) ActualQuantity = _productModel.Quantity;

            else if (_shoppingCartEntry.Quantity < 1) ActualQuantity = 1;

            TotalPrice = (_productModel.Price * _shoppingCartEntry.Quantity).ToString("N2");

        }
    }
}
