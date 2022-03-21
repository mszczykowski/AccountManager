using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels.ProductsViewModels;
using AccountManager.Models;
using System.ComponentModel;
using AccountManager.ViewModels.ManageProductsViewModels;
using AccountManager.ViewModels;
using AccountManager.Services;

namespace AccountManager.Commands.ShopCommands
{
    internal class UpdateShoppingCartCommand : CommandBase
    {
        private ProductsListViewModel _productsListViewModel;
        private ICollection<ShoppingCartEntryModel> _shoppingCart;
        private UserModel _loggedUser;
        private readonly IShoppingCartDatabaseService _shoppingCartDatabaseService;

        public UpdateShoppingCartCommand(ProductsListViewModel productsListViewModel, UserModel loggedUser,
            IShoppingCartDatabaseService shoppingCartDatabaseService)
        {
            _loggedUser = loggedUser;

            _productsListViewModel = productsListViewModel;
            _shoppingCart = _loggedUser.ShoppingCart;

            
            _shoppingCartDatabaseService = shoppingCartDatabaseService;
            SetPropertyChangeEventListeners();
        }

        private void SetPropertyChangeEventListeners()
        {
            _productsListViewModel.Products.ToList().ForEach(p =>
            {
                p.PropertyChanged += OnViewModelPropertyChanged;
            });
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductViewModel.IsChecked)) Execute(sender);
        }

        public override void Execute(object? parameter)
        {
            var product = parameter as ProductViewModel;

            var shoppingCartEntry = new ShoppingCartEntryModel(product.Product);

            if(_shoppingCart.Contains(shoppingCartEntry))
            {
                _shoppingCart.Remove(shoppingCartEntry);
                _shoppingCartDatabaseService.DeleteProductFromCart(_loggedUser.Id, shoppingCartEntry.Product);
            }
            
            else
            {
                if(product.Quantity > 0)
                {
                    _shoppingCart.Add(shoppingCartEntry);
                    _shoppingCartDatabaseService.AddProductToCart(_loggedUser.Id, shoppingCartEntry.Product);
                }
            }
            
        }
    }
}
