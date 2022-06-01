using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

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

            BackCommand = new NavigateCommand<ManageUsersViewModel>(manageUsersViewNavigationService);
            UpdateOrdersCollection();

            OrderOnClickCommand = new NavigateToOrderDetailsCommand(orderStore, manageUserOrderDetailsViewNavigationService);
        }

        
    }
}
