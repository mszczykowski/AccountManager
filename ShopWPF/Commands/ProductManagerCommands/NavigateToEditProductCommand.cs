using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Stores;
using ShopWPF.Services;
using ShopWPF.Models;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.ViewModels.ProductsViewModels;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class NavigateToEditProductCommand : CommandBase
    {
        private ProductStore _productStore;
        
        private readonly NavigationService<EditProductViewModel> _editProductViewModelNavigationService;

        public NavigateToEditProductCommand(ProductStore productStore, NavigationService<EditProductViewModel> editProductViewModelNavigationService)
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
