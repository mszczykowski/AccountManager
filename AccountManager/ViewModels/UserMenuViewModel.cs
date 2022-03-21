using AccountManager.Commands;
using AccountManager.Commands.MisicCommands;
using AccountManager.Services;
using AccountManager.ViewModels.ShopViewModels;
using AccountManager.ViewModels.UserViews;
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

        public UserMenuViewModel(NavigationService<ProductsShopViewModel> productsViewNavigationService,
            NavigationService<UserOrdersViewModel> orderHistoryViewNavigationService,
            NavigationService<LogInViewModel> logInViewNavigationService)
        {
            ProductsNavigateCommand = new NavigateCommand<ProductsShopViewModel>(productsViewNavigationService);

            OrderHistoryNavigateCommand = new NavigateCommand<UserOrdersViewModel>(orderHistoryViewNavigationService);

            LogOutCommand = new NavigateCommand<LogInViewModel>(logInViewNavigationService);

            ExitCommand = new ExitCommand();
        }
    }
}
