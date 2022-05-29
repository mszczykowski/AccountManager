using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Enums;
using ShopWPF.Services;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.UserViews
{
    internal class UserOrderDetailsViewModel : OrderDetailsViewModel
    {
        public ICommand CancelOrderCommand { get; }

        public ICommand UpdateStatusCommand { get; }

        public string OrderStatus => _order.Status.ToString();

        public OrderStatuses OrderStausEnum => (OrderStatuses)_order.StatusId;

        public UserOrderDetailsViewModel(IProductManagerService productManagerService, 
            NavigationService<UserOrdersViewModel> userOrdersViewNavigationService,
            OrderStore orderStore, IOrderManagerService orderManagerService,
            IShopService shopService) : base(productManagerService, orderStore, orderManagerService)
        {
            
            BackCommand = new NavigateCommand<UserOrdersViewModel>(userOrdersViewNavigationService);
            
            CancelOrderCommand = new CancelOrderCommand(this, shopService,
                userOrdersViewNavigationService);

            
        }
    }
}
