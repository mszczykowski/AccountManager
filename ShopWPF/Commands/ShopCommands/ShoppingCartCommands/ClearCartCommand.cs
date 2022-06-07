using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.ViewModels.ShopViewModels;
using ShopWPF.Stores;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.Commands.ShopCommands.ShoppingCartCommands
{
    internal class ClearCartCommand : CommandBase
    {
        private ShoppingCartViewModel _shoppingCartViewModel;
        private IShoppingCartService _shoppingCartDatabaseService;
        private readonly LoggedUserStore _loggedUserStore;

        public ClearCartCommand(ShoppingCartViewModel shoppingCartViewModel,
            IShoppingCartService shoppingCartDatabaseService, LoggedUserStore loggedUserStore)
        {
            _shoppingCartViewModel = shoppingCartViewModel;

            _shoppingCartDatabaseService = shoppingCartDatabaseService;
            _loggedUserStore = loggedUserStore;
        }

        public override async void Execute(object? parameter)
        {
            _loggedUserStore.User.ShoppingCart.Clear();
            await _shoppingCartDatabaseService.ClearCart(_loggedUserStore.User.UserId);
            _shoppingCartViewModel.UpdateShoppingCartEntries();
            _shoppingCartViewModel.UpdateView();
        }
    }
}
