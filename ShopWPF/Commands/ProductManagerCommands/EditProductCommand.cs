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
        private readonly EditProductViewModel _editProductViewModel;
        private readonly NavigationService<ManageProductsViewModel> _manageProductsViewModelNavigationService;
        private readonly IProductManagerService _productsManagerService;
        private readonly ProductStore _productStore;

        public EditProductCommand(EditProductViewModel editProductViewModel, 
            NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService,
            IProductManagerService productsManagerService, ProductStore productStore)
        {
            _editProductViewModel = editProductViewModel;
            _manageProductsViewModelNavigationService = manageProductsViewModelNavigationService;
            _productsManagerService = productsManagerService;
            _productStore = productStore;
        }


        public override void Execute(object? parameter)
        {
            _editProductViewModel.ValidateForm();

            if (_editProductViewModel.HasErrors) return;

            _productsManagerService.EditProduct(_productStore.Product.ProductId ,new ProductModel(_editProductViewModel.ProductName, _editProductViewModel.Price,
                _editProductViewModel.Quantity, _editProductViewModel.Category.CategoryId));

            MessageBox.Show("Product edited!");

            _manageProductsViewModelNavigationService.Navigate();
        }
    }
}
