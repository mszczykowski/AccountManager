using ShopWPF.Services.Common;
using ShopWPF.Stores;
using ShopWPF.ViewModels;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using System;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class NavigateToUserOrdersCommand : CommandBase
    {
        private UserStore _userStore;

        private readonly NavigationService<ManageUserOrdersViewModel> _userOrdersViewNavigationService;

        public NavigateToUserOrdersCommand(UserStore userStore,
            NavigationService<ManageUserOrdersViewModel> userOrdersViewNavigationService)
        {
            _userStore = userStore;
            _userOrdersViewNavigationService = userOrdersViewNavigationService;
        }

        public override void Execute(object? parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            UserViewModel user = parameter as UserViewModel;

            _userStore.User = user.User;

            _userOrdersViewNavigationService.Navigate();
        }
    }
}