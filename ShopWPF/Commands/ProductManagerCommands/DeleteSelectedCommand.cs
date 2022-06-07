using ShopWPF.Services;
using ShopWPF.ViewModels;
using ShopWPF.ViewModels.ProductsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class DeleteSelectedCommand : CommandBase
    {
        private readonly ManageProductsViewModel _manageProductsViewModel;
        private readonly IEnumerable<ProductViewModel> _productsList;
        private readonly IProductManagerService _productsManagerService;

        public DeleteSelectedCommand(ManageProductsViewModel manageProductsViewModel, IProductManagerService productsManagerService)
        {
            _manageProductsViewModel = manageProductsViewModel;

            _productsList = _manageProductsViewModel.Products;
            _productsManagerService = productsManagerService;

            /*foreach(var product in _productsViewModel)
            {
                product.PropertyChanged += OnViewModelPropertyChanged;
            }*/
        }

        public override void Execute(object? parameter)
        {
            bool canExecute = false;

            if (!_productsList.Any(p => p.IsChecked))
            {
                MessageBox.Show("Nothing selected!");
                return;
            }

            if (MessageBox.Show("Delete selected items?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            foreach (var product in _productsList)
            {
                if (product.IsChecked) _productsManagerService.DeleteProduct(product.Product.ProductId);
            }

            _manageProductsViewModel.IsCacheValid = false;
            _manageProductsViewModel.UpdateProductsCollection();
        }
    }
}
