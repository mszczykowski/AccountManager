using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.Models;
using ShopWPF.Stores;
using System.Windows;
using System.ComponentModel;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class EditProductCommand : CommandBase
    {
        private readonly EditProductViewModel _productViewModel;
        private readonly NavigationService<ManageProductsViewModel> _manageProductsViewModelNavigationService;
        private readonly IProductManagerService _productsManagerService;

        public EditProductCommand(EditProductViewModel editProductViewModel, 
            NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService,
            IProductManagerService productsManagerService)
        {
            _productViewModel = editProductViewModel;
            _manageProductsViewModelNavigationService = manageProductsViewModelNavigationService;
            _productsManagerService = productsManagerService;
        }


        public override async void Execute(object? parameter)
        {
            _productViewModel.ValidateForm();

            if (_productViewModel.HasErrors) return;

            await _productsManagerService.EditProduct(_productViewModel.Id,
                new ProductModel(_productViewModel.ProductName, _productViewModel.Price,
                _productViewModel.Quantity, _productViewModel.Category.CategoryId));

            MessageBox.Show("Product edited!");

            _manageProductsViewModelNavigationService.Navigate();
        }
    }
}
