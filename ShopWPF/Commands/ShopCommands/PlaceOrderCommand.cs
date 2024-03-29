﻿using System.ComponentModel;
using System.Linq;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ShopViewModels;
using System.Windows;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.Commands.ShopCommands
{
    internal class PlaceOrderCommand : CommandBase
    {
        private readonly ShoppingCartViewModel _shopCartViewModel;

        private readonly LoggedUserStore _loggedUserStore;

        private readonly NavigationService<ProductsShopViewModel> _productsShopViewNavigationService;

        private readonly IShopService _shopService;

        public PlaceOrderCommand(LoggedUserStore loggedUserStore,
            NavigationService<ProductsShopViewModel> productsShopViewNavigationService,
            IShopService shopService,
            ShoppingCartViewModel shopCartViewModel)
        {
            _loggedUserStore = loggedUserStore;

            _shopService = shopService;

            _shopCartViewModel = shopCartViewModel;

            _productsShopViewNavigationService = productsShopViewNavigationService;
        }


        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShoppingCartViewModel.ShoppingCartEntries)) OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return _shopCartViewModel.ShoppingCartEntries.Count() > 0 && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            if (MessageBox.Show("Place order?", "Order", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            await _shopService.PlaceOrder(_loggedUserStore.User);

            _productsShopViewNavigationService.Navigate();

            MessageBox.Show("Order placed");
        }
    }
}
