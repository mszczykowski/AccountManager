using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Services;
using ShopWPF.Commands;
using ShopWPF.Enums;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Stores;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class EditProductViewModel : ViewModelBase
    {
        private readonly ProductStore _productStore;
        
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

        public ICommand EditProductCommand { get; }
        public ICommand CancelCommand { get; }

        public EditProductViewModel(NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductsManagerService productsManagerService, 
            ProductStore productStore)
        {
            _productStore = productStore;

            _productName = _productStore.Product.Name;
            _price = _productStore.Product.Price;
            _category = _productStore.Product.Category;
            _quantity = _productStore.Product.Quantity;
            
            CancelCommand = new NavigateCommand<ManageProductsViewModel>(manageProductsViewModelNavigationService);

            EditProductCommand = new EditProductCommand(this, manageProductsViewModelNavigationService, productsManagerService, productStore);

        }
    }
}
