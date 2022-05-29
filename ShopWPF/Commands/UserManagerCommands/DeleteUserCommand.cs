using System;
using ShopWPF.ViewModels;
using System.Windows;
using ShopWPF.Services;
using ShopWPF.Stores;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class DeleteUserCommand : CommandBase
    {
        private readonly NavigationService<ManageUsersViewModel> _manageUsersViewModelNavigationSercvice;
        private readonly UserStore _userStore;
        private readonly IUserManagerService _usersManagerService;

        public DeleteUserCommand(SearchUserViewModel searchUserViewModel, NavigationService<ManageUsersViewModel> manageUsersViewModelNavigationSercvice, UserStore userStore,
            IUserManagerService usersManagerService)
        {
            _manageUsersViewModelNavigationSercvice = manageUsersViewModelNavigationSercvice;
            _userStore = userStore;
            _usersManagerService = usersManagerService;

            _userStore.CurrentUserChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, EventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (_usersManagerService.GetUser(_userStore.User?.Name) != null) && base.CanExecute(parameter);
        }


        public override void Execute(object? parameter)
        {
            if (_userStore.User.HasAdminPermissions()) MessageBox.Show("Can't delete admin account!");
            else if (MessageBox.Show("Delete user \"" + _userStore.User.Name + "\" ?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _usersManagerService.DeleteUser(_userStore.User.UserId);
                
                _manageUsersViewModelNavigationSercvice.Navigate();
            }
        }

    }
}
