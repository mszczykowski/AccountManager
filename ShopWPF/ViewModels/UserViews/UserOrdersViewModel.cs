using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Commands.UserManagerCommands;
using ShopWPF.Services;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.ViewModels.UserViews
{
    internal class UserOrdersViewModel : OrdersListViewModel
    {
        
        
        public UserOrdersViewModel(IOrderManagerService orderManagerService, LoggedUserStore loggedUser, 
            NavigationService<UserMenuViewModel> userMenuViewNavigationService, OrderStore orderStore,
            NavigationService<UserOrderDetailsViewModel> userOrderDetailsViewNavigationService) 
            : base(orderManagerService)
        {
            _customer = loggedUser.User;

            BackCommand = new NavigateCommand<UserMenuViewModel>(userMenuViewNavigationService);

            UpdateOrdersCollection();

            OrderOnClickCommand = new NavigateToOrderDetailsCommand(orderStore, 
                userOrderDetailsViewNavigationService);
        }
    }
}
