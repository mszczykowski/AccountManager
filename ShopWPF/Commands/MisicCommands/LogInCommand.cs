using System.ComponentModel;
using ShopWPF.ViewModels;
using System.Windows;
using ShopWPF.Services;
using ShopWPF.Stores;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.Commands.MisicCommands
{
    internal class LogInCommand : CommandBase
    {
        private readonly LogInViewModel _logInViewModel;
        private readonly LoggedUserStore _loggedUserStore;
        private readonly IShoppingCartService _shoppingCartDatabaseService;
        private readonly IProductManagerService _productsManagerService;
        private readonly IUserManagerService _usersManagerService;
        private readonly NavigationService<AdminMenuViewModel> _adminMenuViewNavigationService;
        private readonly NavigationService<UserMenuViewModel> _userMenuViewNavigationService;

        public LogInCommand(LogInViewModel logInViewModel, IUserManagerService usersManagerService, 
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService,
            NavigationService<UserMenuViewModel> userMenuViewNavigationService, LoggedUserStore loggedUserStore, 
            IShoppingCartService shoppingCartDatabaseService, IProductManagerService productsManagerService)
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

        public override async void Execute(object? parameter)
        {
            var user = await _usersManagerService.GetUser(_logInViewModel.Username);

            if (user == null) MessageBox.Show("User not found");

            else if (!user.IsPasswordValid(_logInViewModel.Password)) MessageBox.Show("Password incorrect!");

            else
            {
                _loggedUserStore.User = user;

                _loggedUserStore.User.ShoppingCart = await _shoppingCartDatabaseService.LoadCart(user.UserId);

                if (!user.HasAdminPermissions()) _userMenuViewNavigationService.Navigate();

                else _adminMenuViewNavigationService.Navigate();
            }

        }
    }
}
