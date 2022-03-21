using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels;
using AccountManager.Models;
using System.Windows;
using AccountManager.Services;
using AccountManager.Stores;

namespace AccountManager.Commands.MisicCommands
{
    internal class LogInCommand : CommandBase
    {
        private readonly LogInViewModel _logInViewModel;
        private readonly LoggedUserStore _loggedUserStore;
        private readonly IShoppingCartDatabaseService _shoppingCartDatabaseService;
        private readonly IProductsManagerService _productsManagerService;
        private readonly IUsersManagerService _usersManagerService;
        private readonly NavigationService<AdminMenuViewModel> _adminMenuViewNavigationService;
        private readonly NavigationService<UserMenuViewModel> _userMenuViewNavigationService;

        public LogInCommand(LogInViewModel logInViewModel, IUsersManagerService usersManagerService, 
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService,
            NavigationService<UserMenuViewModel> userMenuViewNavigationService, LoggedUserStore loggedUserStore, 
            IShoppingCartDatabaseService shoppingCartDatabaseService, IProductsManagerService productsManagerService)
        {
            _logInViewModel = logInViewModel;
            _usersManagerService = usersManagerService;
            _adminMenuViewNavigationService = adminMenuViewNavigationService;
            _userMenuViewNavigationService = userMenuViewNavigationService;

            _loggedUserStore = loggedUserStore;
            _shoppingCartDatabaseService = shoppingCartDatabaseService;
            _productsManagerService = productsManagerService;
            _logInViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_logInViewModel.Username) && !string.IsNullOrEmpty(_logInViewModel.Password) 
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var user = _usersManagerService.GetUser(_logInViewModel.Username);

            if (user == null) MessageBox.Show("User not found");

            else if (!user.IsPasswordValid(_logInViewModel.Password)) MessageBox.Show("Password incorrect!");

            else
            {
                _loggedUserStore.User = user;

                _loggedUserStore.User.ShoppingCart = _shoppingCartDatabaseService.LoadCart(user.Id, _productsManagerService);

                if (!user.HasAdminPermissions()) _userMenuViewNavigationService.Navigate();

                else _adminMenuViewNavigationService.Navigate();
            }

        }
    }
}
