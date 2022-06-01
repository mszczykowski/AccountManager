using System.Windows.Input;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.ViewModels.DiscountManagerViewModels;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels
{
    internal class AdminMenuViewModel : ViewModelBase
    {
        public ICommand ManageUsersCommand { get; }

        public ICommand ManageProductsCommand { get; }

        public ICommand ManageDiscountsCommand { get; }

        public ICommand ExitCommand { get; }

        public ICommand LogOutCommand { get; }

        public AdminMenuViewModel(NavigationService<ManageUsersViewModel> manageUsersViewNavigationService,
            NavigationService<ManageProductsViewModel> manageProductsViewNavigationService, 
            NavigationService<LogInViewModel> logInViewNavigationService, 
            NavigationService<DiscountManagerViewModel> manageDiscountsViewNavigationService)
        {
            ManageUsersCommand = new NavigateCommand<ManageUsersViewModel>(manageUsersViewNavigationService);

            LogOutCommand = new NavigateCommand<LogInViewModel>(logInViewNavigationService);

            ManageDiscountsCommand = new NavigateCommand<DiscountManagerViewModel>(manageDiscountsViewNavigationService);

            ExitCommand = new ExitCommand();

            ManageProductsCommand = new NavigateCommand<ManageProductsViewModel>(manageProductsViewNavigationService);
        }
    }
}
