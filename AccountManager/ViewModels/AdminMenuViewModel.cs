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
    internal class AdminMenuViewModel : ViewModelBase
    {
        public ICommand ManageUsersCommand { get; }

        public ICommand ManageProductsCommand { get; }

        public ICommand ManageDiscountsCommand { get; }

        public ICommand ExitCommand { get; }

        public ICommand LogOutCommand { get; }

        public AdminMenuViewModel(NavigationService manageUsersViewNavigationService,
            NavigationService manageProductsViewNavigationService, 
            NavigationService logInViewNavigationService, NavigationService manageDiscountsViewNavigationService)
        {
            ManageUsersCommand = new NavigateCommand(manageUsersViewNavigationService);

            LogOutCommand = new NavigateCommand(logInViewNavigationService);

            ManageDiscountsCommand = new NavigateCommand(manageDiscountsViewNavigationService);

            ExitCommand = new ExitCommand();

            ManageProductsCommand = new NavigateCommand(manageProductsViewNavigationService);
        }
    }
}
