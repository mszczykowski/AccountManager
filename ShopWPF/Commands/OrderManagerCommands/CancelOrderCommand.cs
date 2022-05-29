using ShopWPF.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Services;
using ShopWPF.Enums;
using System.Windows;
using ShopWPF.ViewModels.UserViews;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.Commands.OrderManagerCommands
{
    internal class CancelOrderCommand : CommandBase
    {
        private readonly NavigationService<UserOrdersViewModel> _userOrdersViewNavigationService;
        private readonly IShopService _shopService;
        private UserOrderDetailsViewModel _orderDetailsViewModel;
        public CancelOrderCommand(UserOrderDetailsViewModel orderDetailsViewModel,
            IShopService shopService,
            NavigationService<UserOrdersViewModel> userOrdersViewNavigationService)
        {
            _userOrdersViewNavigationService = userOrdersViewNavigationService;
            _orderDetailsViewModel = orderDetailsViewModel;
            _shopService = shopService;

            OnCanExecuteChanged();
            
        }

        public override bool CanExecute(object? parameter)
        {
            return _orderDetailsViewModel.OrderStausEnum == OrderStatuses.New && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            if (MessageBox.Show("Cancel order?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                await _shopService.CancelOrder(_orderDetailsViewModel.Order);
            }

            _userOrdersViewNavigationService.Navigate();
        }
    }
}
