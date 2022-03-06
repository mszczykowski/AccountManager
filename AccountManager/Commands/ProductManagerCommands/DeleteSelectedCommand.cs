using AccountManager.Services;
using AccountManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountManager.ViewModels;

namespace AccountManager.Commands.ProductManagerCommands
{
    internal class DeleteSelectedCommand : CommandBase
    {
        private readonly ManageProductsViewModel _manageProductsViewModel;
        private readonly IEnumerable<ProductViewModel> _productsViewModel;
        private readonly IProductsManagerService _productsManagerService;

        public DeleteSelectedCommand(ManageProductsViewModel manageProductsViewModel, IProductsManagerService productsManagerService)
        {
            _manageProductsViewModel = manageProductsViewModel;

            _productsViewModel = _manageProductsViewModel.Products;
            _productsManagerService = productsManagerService;

            foreach(var product in _productsViewModel)
            {
                product.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductViewModel.IsChecked)) OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            bool canExecute = false;
            
            foreach (var product in _productsViewModel)
            {
                if(product.IsChecked)
                {
                    canExecute = true;
                    break;
                }    
            }

            return canExecute && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Delete selected items?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var product in _productsViewModel)
                {
                    if (product.IsChecked) _productsManagerService.DeleteProduct(product.Product.Id);
                }

                _manageProductsViewModel.UpdateProductsCollection();
            }
        }
    }
}
