using System.ComponentModel;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.Models;
using System.Windows;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class AddProductCommand : CommandBase
    {
        private readonly ProductFormViewModel _productViewModel;
        private readonly NavigationService<ManageProductsViewModel> _manageProductsViewModelNavigationService;
        private readonly IProductManagerService _productsManagerService;

        public AddProductCommand(ProductFormViewModel productViewModel, 
            NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductManagerService productsManagerService)
        {
            _productViewModel = productViewModel;
            _manageProductsViewModelNavigationService = manageProductsViewModelNavigationService;
            _productsManagerService = productsManagerService;
        }

        public override void Execute(object? parameter)
        {
            _productViewModel.ValidateForm();

            if (_productViewModel.HasErrors) return;

            _productsManagerService.AddProduct(new ProductModel(_productViewModel.ProductName, _productViewModel.Price,
                _productViewModel.Quantity, _productViewModel.Category.CategoryId));

            MessageBox.Show("Product created!");

            _manageProductsViewModelNavigationService.Navigate();
        }
    }
}
