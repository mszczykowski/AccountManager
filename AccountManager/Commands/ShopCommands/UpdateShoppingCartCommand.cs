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

namespace AccountManager.Commands.ShopCommands
{
    internal class UpdateShoppingCartCommand : CommandBase
    {
        private ProductsListViewModel _productsListViewModel;
        private ICollection<ShoppingCartEntryModel> _shoppingCart;

        public UpdateShoppingCartCommand(ProductsListViewModel productsListViewModel, ICollection<ShoppingCartEntryModel> shoppingCart)
        {
            _productsListViewModel = productsListViewModel;
            _shoppingCart = shoppingCart;

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

            if(_shoppingCart.Contains(shoppingCartEntry)) _shoppingCart.Remove(shoppingCartEntry);
            else _shoppingCart.Add(shoppingCartEntry);
        }
    }
}
