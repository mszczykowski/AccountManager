using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Services;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.Models;
using System.Windows;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class AddProductCommand : CommandBase
    {
        private readonly AddProductViewModel _addProductViewModel;
        private readonly NavigationService<ManageProductsViewModel> _manageProductsViewModelNavigationService;
        private readonly IProductsManagerService _productsManagerService;

        public AddProductCommand(AddProductViewModel addProductViewModel, 
            NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductsManagerService productsManagerService)
        {
            _addProductViewModel = addProductViewModel;
            _manageProductsViewModelNavigationService = manageProductsViewModelNavigationService;
            _productsManagerService = productsManagerService;

            _addProductViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addProductViewModel.ProductName) && _addProductViewModel.Price > 0
                && _addProductViewModel.Quantity >= 0 && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _productsManagerService.AddProduct(new ProductModel(_addProductViewModel.ProductName, _addProductViewModel.Price,
                _addProductViewModel.Quantity, _addProductViewModel.Category));

            MessageBox.Show("Product created!");

            _manageProductsViewModelNavigationService.Navigate();
        }
    }
}
