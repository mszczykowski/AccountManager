using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Stores;
using AccountManager.Services;
using AccountManager.Models;
using AccountManager.ViewModels;

namespace AccountManager.Commands.ProductManagerCommands
{
    internal class NavigateToEditProductCommand : CommandBase
    {
        private ProductStore _productStore;
        
        private readonly NavigationService _editProductViewModelNavigationService;

        public NavigateToEditProductCommand(ProductStore productStore, NavigationService editProductViewModelNavigationService)
        {
            _productStore = productStore;
            _editProductViewModelNavigationService = editProductViewModelNavigationService;
        }

        public override void Execute(object? parameter)
        {
            if(parameter == null) throw new ArgumentNullException(nameof(parameter));

            ProductViewModel product = parameter as ProductViewModel;

            _productStore.Product = product.Product;

            _editProductViewModelNavigationService.Navigate();
        }
    }
}
