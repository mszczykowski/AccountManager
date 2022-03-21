using AccountManager.Commands.MisicCommands;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Enums;
using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.OrdersViewModels;
using AccountManager.ViewModels.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.ManageOrdersViewModels
{
    internal class ManageUserOrderDetailsViewModel : OrderDetailsViewModel
    {
        private OrderStatuses _orderStatus;
        public OrderStatuses OrderStatus
        {
            get => _orderStatus;
            set
            {
                _orderStatus = value;
                OnPropertyChanged(nameof(OrderStatus));
            }
        }

        public ICommand UpdateStatusCommand { get; }

        public ManageUserOrderDetailsViewModel(IProductsManagerService productManagerService,
            NavigationService<ManageUserOrdersViewModel> manageUserOrdersViewNavigationService, OrderStore orderStrore, IOrderManagerService orderManagerService) : 
            base(productManagerService, orderStrore, orderManagerService)
        {
            _orderStatus = orderStrore.Order.Status;

            BackCommand = new NavigateCommand<ManageUserOrdersViewModel>(manageUserOrdersViewNavigationService);

            UpdateStatusCommand = new UpdateOrderStatusCommand(this, productManagerService, orderManagerService);
        }

    }
}
