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
        public UserOrdersViewModel(NavigationService ManageUsersViewNavigationService, IOrderManagerService orderManagerService, UserStore customer) 
            : base(ManageUsersViewNavigationService, orderManagerService, customer)
        {
        }
    }
}
