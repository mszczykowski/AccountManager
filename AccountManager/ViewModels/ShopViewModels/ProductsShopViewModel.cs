using AccountManager.Commands.ShopCommands;
using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.ProductsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.ShopViewModels
{
    internal class ProductsShopViewModel : ProductsListViewModel
    {
        public ICommand UpdateShoppingCartCommand { get; }
        public ProductsShopViewModel(NavigationService adminMenuViewModelNavigationService, IProductsManagerService productManagerService, 
            LoggedUserStore loggedUserStore) : base(adminMenuViewModelNavigationService, productManagerService)
        {
            UpdateShoppingCartCommand = new UpdateShoppingCartCommand(this, loggedUserStore.LoggedUser.ShoppingCart);
        }
    }
}
