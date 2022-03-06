using AccountManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;

namespace AccountManager.ViewModels
{
    internal class UserMenuViewModel : ViewModelBase
    {
        public ICommand ManageUsersCommand { get; }

        public ICommand ManageProductsCommand { get; }
        public ICommand ExitCommand { get; }

        public ICommand LogOutCommand { get; }

        public UserMenuViewModel(NavigationService manageUsersViewNavigationService,
            NavigationService manageProductsViewNavigationService, 
            NavigationService logInViewNavigationService)
        {
            ManageUsersCommand = new NavigateCommand(manageUsersViewNavigationService);

            LogOutCommand = new NavigateCommand(logInViewNavigationService);

            ExitCommand = new ExitCommand();

            ManageProductsCommand = new NavigateCommand(manageProductsViewNavigationService);
        }
    }
}
