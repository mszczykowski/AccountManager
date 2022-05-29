using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Enums;
using ShopWPF.Services;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;
using ShopWPF.ViewModels.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageOrdersViewModels
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

        public ManageUserOrderDetailsViewModel(IProductManagerService productManagerService,
            NavigationService<ManageUserOrdersViewModel> manageUserOrdersViewNavigationService, OrderStore orderStrore, IOrderManagerService orderManagerService) : 
            base(productManagerService, orderStrore, orderManagerService)
        {
            _orderStatus = (OrderStatuses)orderStrore.Order.StatusId;

            BackCommand = new NavigateCommand<ManageUserOrdersViewModel>(manageUserOrdersViewNavigationService);

            UpdateStatusCommand = new UpdateOrderStatusCommand(this, productManagerService, orderManagerService);
        }

    }
}
