using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Services;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.Models;
using ShopWPF.Stores;
using System.Windows;
using System.ComponentModel;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class EditProductCommand : CommandBase
    {
        private readonly EditProductViewModel _editProductViewModel;
        private readonly NavigationService<ManageProductsViewModel> _manageProductsViewModelNavigationService;
        private readonly IProductsManagerService _productsManagerService;
        private readonly ProductStore _productStore;

        public EditProductCommand(EditProductViewModel editProductViewModel, 
            NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService,
            IProductsManagerService productsManagerService, ProductStore productStore)
        {
            _editProductViewModel = editProductViewModel;
            _manageProductsViewModelNavigationService = manageProductsViewModelNavigationService;
            _productsManagerService = productsManagerService;
            _productStore = productStore;

            _editProductViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_editProductViewModel.ProductName) && _editProductViewModel.Price > 0
                && _editProductViewModel.Quantity >= 0 && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _productsManagerService.EditProduct(_productStore.Product.ProductId ,new ProductModel(_editProductViewModel.ProductName, _editProductViewModel.Price,
                _editProductViewModel.Quantity, _editProductViewModel.Category));

            MessageBox.Show("Product edited!");

            _manageProductsViewModelNavigationService.Navigate();
        }
    }
}
