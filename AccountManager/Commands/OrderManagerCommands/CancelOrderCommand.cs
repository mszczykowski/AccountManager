using AccountManager.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Services;
using AccountManager.Enums;
using System.Windows;
using AccountManager.ViewModels.UserViews;

namespace AccountManager.Commands.OrderManagerCommands
{
    internal class CancelOrderCommand : CommandBase
    {
        private readonly IProductsManagerService _productManager;
        private readonly IOrderManagerService _orderManager;
        private readonly NavigationService<UserOrdersViewModel> _userOrdersViewNavigationService;
        private UserOrderDetailsViewModel _orderDetailsViewModel;
        public CancelOrderCommand(UserOrderDetailsViewModel orderDetailsViewModel,
            IProductsManagerService productManager, IOrderManagerService orderManager,
            NavigationService<UserOrdersViewModel> userOrdersViewNavigationService)
        {
            _productManager = productManager;
            _orderManager = orderManager;
            _userOrdersViewNavigationService = userOrdersViewNavigationService;
            _orderDetailsViewModel = orderDetailsViewModel;

            OnCanExecuteChanged();
            
        }

        public override bool CanExecute(object? parameter)
        {
            return _orderDetailsViewModel.OrderStausEnum == OrderStatuses.New && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Cancel order?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _orderManager.UpdateStatus(_orderDetailsViewModel.Order.Id, OrderStatuses.Canceled);

                _orderDetailsViewModel.Order.Products.ToList().ForEach(p =>
                {
                    _productManager.ReduceProductQantity(p.ProductId, -p.Quantity);
                });
            }

            _userOrdersViewNavigationService.Navigate();
        }
    }
}
