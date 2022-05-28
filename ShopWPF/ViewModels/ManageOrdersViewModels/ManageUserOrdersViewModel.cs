using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Services;
using ShopWPF.Commands;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Models;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Stores;
using System.Collections.ObjectModel;
using ShopWPF.ViewModels.OrdersViewModels;
using System.ComponentModel;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels.ManageOrdersViewModels
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
