using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;

namespace ShopWPF.ViewModels.UserViews
{
    internal class UserOrdersViewModel : OrdersListViewModel
    {
        public UserOrdersViewModel(IOrderManagerService orderManagerService, LoggedUserStore loggedUser, 
            NavigationService<UserMenuViewModel> userMenuViewNavigationService, IdStore idStore,
            NavigationService<UserOrderDetailsViewModel> userOrderDetailsViewNavigationService) 
            : base(orderManagerService)
        {
            _customer = loggedUser.User;

            BackCommand = new NavigateCommand<UserMenuViewModel>(userMenuViewNavigationService);

            OrderOnClickCommand =
                new NaviagteAndStoreIdCommand<UserOrderDetailsViewModel>(userOrderDetailsViewNavigationService, idStore);

            UpdateOrdersCollection();
        }
    }
}
