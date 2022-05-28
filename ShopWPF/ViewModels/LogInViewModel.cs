using ShopWPF.Commands;
using ShopWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Services;
using System.ComponentModel;
using ShopWPF.Models;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels
{
    internal class LogInViewModel : ViewModelBase
    {
        private string _userName;
        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LogInCommand { get; }
        public ICommand CancelCommand { get; }

        public LogInViewModel(NavigationService<MainMenuViewModel> mainMenuViewNavigationService, 
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService,
            NavigationService<UserMenuViewModel> userMenuViewNavigationService, 
            IUserManagerService usersManagerService, 
            LoggedUserStore loggedUserStore,
            IShoppingCartService shoppingCartDatabaseService,
            IProductsManagerService productsManagerService)
        {
            CancelCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewNavigationService);


            LogInCommand = new LogInCommand(this, usersManagerService, adminMenuViewNavigationService, userMenuViewNavigationService, loggedUserStore,
                shoppingCartDatabaseService, productsManagerService);

        }

    }
}
