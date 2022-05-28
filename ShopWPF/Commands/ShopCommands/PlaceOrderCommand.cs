using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ShopViewModels;
using ShopWPF.Services;
using System.Windows;
using ShopWPF.Models;
using ShopWPF.Discounts;

namespace ShopWPF.Commands.ShopCommands
{
    internal class PlaceOrderCommand : CommandBase
    {
        private ShoppingCartViewModel _shopCartViewModel;

        private LoggedUserStore _loggedUserStore;

        private IProductsManagerService _productsManagerService;

        private IOrderManagerService _orderManagerService;

        private NavigationService<ProductsShopViewModel> _productsShopViewNavigationService;

        private DiscountManager _discountManager;

        private IShoppingCartService _shoppingCartDatabaseService;

        public PlaceOrderCommand(ShoppingCartViewModel shopCartViewModel, LoggedUserStore loggedUserStore, IProductsManagerService productsManagerService,
            IOrderManagerService orderManagerService, NavigationService<ProductsShopViewModel> productsShopViewNavigationService,
            DiscountManager discountManager, IShoppingCartService shoppingCartDatabaseService)
        {
            _shopCartViewModel = shopCartViewModel;

            _loggedUserStore = loggedUserStore;

            _productsManagerService = productsManagerService;

            _productsShopViewNavigationService = productsShopViewNavigationService;

            _orderManagerService = orderManagerService;

            _shopCartViewModel.PropertyChanged += OnViewModelPropertyChanged;

            _discountManager = discountManager;

            _shoppingCartDatabaseService = shoppingCartDatabaseService;
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
                double fullPrice = 0;
                double discountValue = 0;

                _shopCartViewModel.ShoppingCartEntries.ToList<ShoppingCartEntryViewModel>().ForEach(entry =>
                {
                    fullPrice += entry.ProductModel.Price * entry.ActualQuantity;
                });

                _discountManager.Discounts.ToList().ForEach(discount =>
                {
                    discountValue += discount.GetDiscountValue(_loggedUserStore.User.ShoppingCart);
                });

                OrderModel order = new OrderModel(_loggedUserStore.User.UserId, fullPrice, discountValue);

                _shopCartViewModel.ShoppingCartEntries.ToList<ShoppingCartEntryViewModel>().ForEach(entry =>
                {
                    _productsManagerService.ChangeQantity(entry.ProductModel.ProductId, entry.ActualQuantity);

                    order.AddProduct(new OrderProductModel(entry.ProductModel.ProductId, entry.ProductModel.Price, entry.ActualQuantity));
                });

                _orderManagerService.AddOrder(order);

                _loggedUserStore.User.ShoppingCart.Clear();

                _shoppingCartDatabaseService.ClearCart(_loggedUserStore.User.UserId);

                _productsShopViewNavigationService.Navigate();

                MessageBox.Show("Order placed");
            }
        }
    }
}
