using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels.ShopViewModels;
using AccountManager.Models;

namespace AccountManager.Commands.ShopCommands.ShoppingCartCommands
{
    internal class ClearCartCommand : CommandBase
    {
        private ShoppingCartViewModel _shoppingCartViewModel;
        private ICollection<ShoppingCartEntryModel> _shoppingCartsEntries;

        public ClearCartCommand(ShoppingCartViewModel shoppingCartViewModel, ICollection<ShoppingCartEntryModel> shoppingCartsEntries)
        {
            _shoppingCartViewModel = shoppingCartViewModel;
            _shoppingCartsEntries = shoppingCartsEntries;
        }

        public override void Execute(object? parameter)
        {
            _shoppingCartsEntries.Clear();
            _shoppingCartViewModel.UpdateShoppingCartEnetries();
        }
    }
}
