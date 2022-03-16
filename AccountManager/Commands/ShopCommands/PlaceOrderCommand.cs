using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Stores;
using AccountManager.ViewModels.ShopViewModels;
using AccountManager.Services;
using System.Windows;
using AccountManager.Models;

namespace AccountManager.Commands.ShopCommands
{
    internal class PlaceOrderCommand : CommandBase
    {
        private ShoppingCartViewModel _shopCartViewModel;

        private LoggedUserStore _loggedUserStore;

        private IProductsManagerService _productsManagerService;

        private IOrderManagerService _orderManagerService;

        private NavigationService _manageProductsShopViewNavigationService;

        public PlaceOrderCommand(ShoppingCartViewModel shopCartViewModel, LoggedUserStore loggedUserStore, IProductsManagerService productsManagerService,
            IOrderManagerService orderManagerService, NavigationService manageProductsShopViewNavigationService)
        {
            _shopCartViewModel = shopCartViewModel;

            _loggedUserStore = loggedUserStore;

            _productsManagerService = productsManagerService;

            _manageProductsShopViewNavigationService = manageProductsShopViewNavigationService;

            _orderManagerService = orderManagerService;

            _shopCartViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShoppingCartViewModel.ShoppingCartEntries)) OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return _shopCartViewModel.ShoppingCartEntries.Count() > 0 && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Place order?", "Order", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderModel order = new OrderModel(_loggedUserStore.User.Id);

                _shopCartViewModel.ShoppingCartEntries.ToList<ShoppingCartEntryViewModel>().ForEach(entry =>
                {
                    _productsManagerService.ReduceProductQantity(entry.ProductModel.Id, entry.ActualQuantity);

                    order.AddProduct(new OrderProductModel(entry.ProductModel.Id, entry.ProductModel.Price, entry.ActualQuantity));
                });

                _orderManagerService.AddOrder(order);

                _loggedUserStore.User.ShoppingCart.Clear();

                _manageProductsShopViewNavigationService.Navigate();

                MessageBox.Show("Order placed");
            }
        }
    }
}
