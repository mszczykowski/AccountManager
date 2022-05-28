using ShopWPF.Services;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.ViewModels.OrdersViewModels;
using ShopWPF.ViewModels.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Commands.OrderManagerCommands
{
    internal class NavigateToOrderDetailsCommand : CommandBase
    {
        private OrderStore _orderStore;

        private readonly NavigationService<ManageUserOrderDetailsViewModel> _manageOrderDetailsViewNavigationService;

        private readonly NavigationService<UserOrderDetailsViewModel> _orderDetailsViewNavigationService;

        public NavigateToOrderDetailsCommand(OrderStore orderStore,
            NavigationService<ManageUserOrderDetailsViewModel> manageOrderDetailsViewNavigationService)
        {
            _orderStore = orderStore;
            _manageOrderDetailsViewNavigationService = manageOrderDetailsViewNavigationService;
        }

        public NavigateToOrderDetailsCommand(OrderStore orderStore,
            NavigationService<UserOrderDetailsViewModel> orderDetailsViewNavigationService)
        {
            _orderStore = orderStore;
            _orderDetailsViewNavigationService = orderDetailsViewNavigationService;
        }

        public override void Execute(object? parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            OrderViewModel orderViewModel = parameter as OrderViewModel;

            _orderStore.Order = orderViewModel.Order;

            if (_orderDetailsViewNavigationService != null) _orderDetailsViewNavigationService.Navigate();
            else _manageOrderDetailsViewNavigationService.Navigate();
        }
    }
}
