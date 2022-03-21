using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels.ShopViewModels;
using AccountManager.Models;
using AccountManager.Services;
using AccountManager.Stores;

namespace AccountManager.Commands.ShopCommands.ShoppingCartCommands
{
    internal class ClearCartCommand : CommandBase
    {
        private ShoppingCartViewModel _shoppingCartViewModel;
        private IShoppingCartDatabaseService _shoppingCartDatabaseService;
        private readonly LoggedUserStore _loggedUserStore;

        public ClearCartCommand(ShoppingCartViewModel shoppingCartViewModel,
            IShoppingCartDatabaseService shoppingCartDatabaseService, LoggedUserStore loggedUserStore)
        {
            _shoppingCartViewModel = shoppingCartViewModel;

            _shoppingCartDatabaseService = shoppingCartDatabaseService;
            _loggedUserStore = loggedUserStore;
        }

        public override void Execute(object? parameter)
        {
            _loggedUserStore.User.ShoppingCart.Clear();
            _shoppingCartDatabaseService.ClearCart(_loggedUserStore.User.Id);
            _shoppingCartViewModel.UpdateShoppingCartEnetries();
            _shoppingCartViewModel.UpdateView();
        }
    }
}
