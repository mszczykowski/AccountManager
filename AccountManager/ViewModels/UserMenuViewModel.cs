using AccountManager.Commands;
using AccountManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels
{
    internal class UserMenuViewModel : ViewModelBase
    {
        public ICommand ProductsNavigateCommand { get; }

        public ICommand OrderHistoryNavigateCommand { get; }

        public ICommand ExitCommand { get; }

        public ICommand LogOutCommand { get; }

        public UserMenuViewModel(NavigationService productsViewNavigationService,
            NavigationService orderHistoryViewNavigationService,
            NavigationService logInViewNavigationService)
        {
            ProductsNavigateCommand = new NavigateCommand(productsViewNavigationService);

            OrderHistoryNavigateCommand = new NavigateCommand(orderHistoryViewNavigationService);

            LogOutCommand = new NavigateCommand(logInViewNavigationService);

            ExitCommand = new ExitCommand();
        }
    }
}
