using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.ManageOrdersViewModels;
using AccountManager.ViewModels.OrdersViewModels;
using AccountManager.ViewModels.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Commands.OrderManagerCommands
{
    internal class NavigateToOrderDetailsCommand : CommandBase
    {
        private OrderStore _orderStore;

        private readonly NavigationService<UserOrderDetailsViewModel> _orderDetailsViewNavigationService;

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

            _orderDetailsViewNavigationService.Navigate();
        }
    }
}
