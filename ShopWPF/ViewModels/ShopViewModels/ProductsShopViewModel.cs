using ShopWPF.Commands.ShopCommands;
using ShopWPF.Services;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ProductsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Commands;
using ShopWPF.Models;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels.ShopViewModels
{
    internal class ProductsShopViewModel : ProductsListViewModel
    {
        private LoggedUserStore _loggedUserStore;

        public ICommand UpdateShoppingCartCommand { get; }

        public ICommand NavigateToCartCommand { get; }

        public ProductsShopViewModel(NavigationService<UserMenuViewModel> userMenuViewModelNavigationService, 
            NavigationService<ShoppingCartViewModel> shoppingCartViewModelNavigationService,
            IProductsManagerService productManagerService, LoggedUserStore loggedUserStore,
            IShoppingCartService shoppingCartDatabaseService)
            : base(productManagerService)
        {
            _loggedUserStore = loggedUserStore;

            LoadShoppingCartState();

            UpdateShoppingCartCommand = new UpdateShoppingCartCommand(this, _loggedUserStore.User, shoppingCartDatabaseService);

            NavigateToCartCommand = new NavigateCommand<ShoppingCartViewModel>(shoppingCartViewModelNavigationService);

            BackCommand = new NavigateCommand<UserMenuViewModel>(userMenuViewModelNavigationService);
        }

        private void LoadShoppingCartState()
        {
            foreach(var product in _products)
            {
                if (_loggedUserStore.User.ShoppingCart.Contains(new ShoppingCartEntryModel(product.Product)))
                    product.IsChecked = true;
            }
        }
    }
}
