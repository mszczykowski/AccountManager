using AccountManager.Commands.MisicCommands;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Commands.UserManagerCommands;
using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.ViewModels.UserViews
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
