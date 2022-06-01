using System.Windows.Input;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Stores;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Models;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class EditProductViewModel : ProductFormViewModel
    {
        public ICommand EditProductCommand { get; }

        private ProductStore _productStore;

        public EditProductViewModel(NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductManagerService productManagerService, 
            ProductStore productStore) : base (manageProductsViewModelNavigationService)
        {
            _productStore = productStore;

            ProductName = _productStore.Product.Name;
            Price = _productStore.Product.Price;
            Category = _productStore.Product.Category;
            Quantity = _productStore.Product.Quantity;

            EditProductCommand = new EditProductCommand(this, manageProductsViewModelNavigationService, productManagerService, productStore);

        }
    }
}
