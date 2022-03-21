using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;
using AccountManager.Commands;
using AccountManager.Commands.ProductManagerCommands;
using AccountManager.Models;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Stores;
using System.Collections.ObjectModel;
using AccountManager.ViewModels.OrdersViewModels;
using System.ComponentModel;
using AccountManager.Commands.MisicCommands;

namespace AccountManager.ViewModels.ManageOrdersViewModels
{
    internal class ManageUserOrdersViewModel : OrdersListViewModel
    {

        public string CustomerName => _customer.Name;



        public ManageUserOrdersViewModel(NavigationService<ManageUsersViewModel> manageUsersViewNavigationService, 
            IOrderManagerService orderManagerService, UserStore customer, OrderStore orderStore,
            NavigationService<ManageUserOrderDetailsViewModel> manageUserOrderDetailsViewNavigationService)
            : base(orderManagerService)
        {
            _customer = customer.User;

            //SetOnPropertyChangedListener();

            BackCommand = new NavigateCommand<ManageUsersViewModel>(manageUsersViewNavigationService);
            UpdateOrdersCollection();

            OrderOnClickCommand = new NavigateToOrderDetailsCommand(orderStore, manageUserOrderDetailsViewNavigationService);
        }

        
    }
}
