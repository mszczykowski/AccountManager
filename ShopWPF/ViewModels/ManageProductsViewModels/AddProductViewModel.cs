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
using ShopWPF.Commands.MisicCommands;
using System.ComponentModel;
using System.Collections;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class AddProductViewModel : ViewModelBase
    {
        private readonly ErrorsViewModel _errorsViewModel;
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

        private CategoryModel _category;
        public CategoryModel Category
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
                ValidatePrice();
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

        public AddProductViewModel(NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductManagerService productsManagerService)
        {
            CancelCommand = new NavigateCommand<ManageProductsViewModel>(manageProductsViewModelNavigationService);

            AddProductCommand = new AddProductCommand(this, manageProductsViewModelNavigationService, productsManagerService);


            _errorsViewModel = new ErrorsViewModel();

            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errorsViewModel.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public void ValidatePrice()
        {
            _errorsViewModel.ClearErrors(nameof(Price));

            if (_price > 10) _errorsViewModel.AddError(nameof(Price), "Klucz nie może być pusty");
        }
    }
}
