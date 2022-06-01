using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Enums;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;
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
