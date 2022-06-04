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
        private int _id;
        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        public ICommand EditProductCommand { get; }

        public EditProductViewModel(NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductManagerService productManagerService, 
            IdStore idStore, ICategoryManagerService categoryManagerService) 
            : base (manageProductsViewModelNavigationService, categoryManagerService)
        {
            LoadProduct(idStore.Id, productManagerService);

            EditProductCommand = 
                new EditProductCommand(this, manageProductsViewModelNavigationService, productManagerService);

        }

        private async void LoadProduct(int id, IProductManagerService productManagerService)
        {
            var product = await productManagerService.GetProduct(id);

            Id = product.ProductId;
            ProductName = product.Name;
            Price = product.Price;
            Category = product.Category;
            Quantity = product.Quantity;
        }
    }
}
