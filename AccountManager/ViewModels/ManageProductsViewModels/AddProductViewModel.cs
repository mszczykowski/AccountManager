using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;
using AccountManager.Commands;
using AccountManager.Enums;
using AccountManager.Commands.ProductManagerCommands;

namespace AccountManager.ViewModels.ManageProductsViewModels
{
    internal class AddProductViewModel : ViewModelBase
    {
        private string _productName;
        public string ProductName 
        {
            get => _productName; 
            set 
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            } 
        }

        private Categories _category;
        public Categories Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private double _price;
        public double Price 
        { 
            get => _price; 
            set 
            { 
                _price = value; 
                OnPropertyChanged(nameof(Price)); 
            } 
        }

        private int _quantity;
        public int Quantity 
        { 
            get => _quantity; 
            set 
            { 
                _quantity = value; 
                OnPropertyChanged(nameof(Quantity));  
            } 
        }

        public ICommand AddProductCommand { get; }
        public ICommand CancelCommand { get; }

        public AddProductViewModel(NavigationService manageProductsViewModelNavigationService, IProductsManagerService productsManagerService)
        {
            CancelCommand = new NavigateCommand(manageProductsViewModelNavigationService);

            AddProductCommand = new AddProductCommand(this, manageProductsViewModelNavigationService, productsManagerService);

        }
    }
}
