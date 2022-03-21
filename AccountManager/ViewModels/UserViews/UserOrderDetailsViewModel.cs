using AccountManager.Commands.MisicCommands;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Enums;
using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.UserViews
{
    internal class UserOrderDetailsViewModel : OrderDetailsViewModel
    {
        public ICommand CancelOrderCommand { get; }

        public ICommand UpdateStatusCommand { get; }

        public string OrderStatus => _order.Status.ToString();

        public OrderStatuses OrderStausEnum => _order.Status;

        public UserOrderDetailsViewModel(IProductsManagerService productManagerService, 
            NavigationService<UserOrdersViewModel> userOrdersViewNavigationService,
            OrderStore orderStore, IOrderManagerService orderManagerService) : base(productManagerService, orderStore, orderManagerService)
        {
            
            BackCommand = new NavigateCommand<UserOrdersViewModel>(userOrdersViewNavigationService);
            
            CancelOrderCommand = new CancelOrderCommand(this, productManagerService, orderManagerService,
                userOrdersViewNavigationService);

            
        }
    }
}
