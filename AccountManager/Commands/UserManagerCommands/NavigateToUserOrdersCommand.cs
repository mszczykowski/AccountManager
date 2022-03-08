using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Stores;
using AccountManager.Services;
using AccountManager.Models;
using AccountManager.ViewModels;

namespace AccountManager.Commands.UserManagerCommands
{
    internal class NavigateToUserOrdersCommand : CommandBase
    {
        private UserStore _userStore;

        private readonly NavigationService _userOrdersViewNavigationService;

        public NavigateToUserOrdersCommand(UserStore userStore, NavigationService userOrdersViewNavigationService)
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
