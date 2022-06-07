using System.Collections.Generic;
using System.Linq;
using ShopWPF.ViewModels.ProductsViewModels;
using ShopWPF.Models;
using System.ComponentModel;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.Commands.ShopCommands
{
    internal class UpdateShoppingCartCommand : CommandBase
    {
        private ProductsListViewModel _productsListViewModel;
        private ICollection<ShoppingCartEntryModel> _shoppingCart;
        private UserModel _loggedUser;
        private readonly IShoppingCartService _shoppingCartDatabaseService;

        public UpdateShoppingCartCommand(ProductsListViewModel productsListViewModel, UserModel loggedUser,
            IShoppingCartService shoppingCartDatabaseService)
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

        public override async void Execute(object? parameter)
        {
            var product = parameter as ProductViewModel;

            var shoppingCartEntry = new ShoppingCartEntryModel(product.Product);

            if(_shoppingCart.Contains(shoppingCartEntry))
            {
                await _shoppingCartDatabaseService.DeleteProductFromCart(_loggedUser.UserId, shoppingCartEntry.Product);
            }
            
            else
            {
                if(product.Quantity > 0)
                {
                    await _shoppingCartDatabaseService.AddProductToCart(_loggedUser.UserId, shoppingCartEntry.Product);
                }
            }
            _shoppingCart = await _shoppingCartDatabaseService.LoadCart(_loggedUser.UserId);
        }
    }
}
