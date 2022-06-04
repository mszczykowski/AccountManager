using System.Windows.Input;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ProductsViewModels;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class ManageProductsViewModel : ProductsListViewModel
    {
        public ICommand AddProductCommand { get; }

        public ICommand EditProductCommand { get; }

        public ICommand DeleteSelectedCommand { get; private set; }

        public ManageProductsViewModel(NavigationService<AdminMenuViewModel> adminMenuViewModelNavigationService, 
            NavigationService<AddProductViewModel> addProductViewModelNavigationService,
            NavigationService<EditProductViewModel> editProductViewModelNavigationService, 
            IProductManagerService productManagerService, 
            IdStore idStore, ICategoryManagerService categoryManagerService) 
            : base(productManagerService, categoryManagerService)
        {
            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewModelNavigationService);

            AddProductCommand = new NavigateCommand<AddProductViewModel>(addProductViewModelNavigationService);

            EditProductCommand = 
                new NaviagteAndStoreIdCommand<EditProductViewModel>(editProductViewModelNavigationService, idStore);

            DeleteSelectedCommand = new DeleteSelectedCommand(this, _productManagerService);
        }
    }
}
