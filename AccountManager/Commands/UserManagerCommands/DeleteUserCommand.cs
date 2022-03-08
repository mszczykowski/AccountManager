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

namespace AccountManager.Commands
{
    internal class DeleteUserCommand : CommandBase
    {
        private readonly NavigationService _manageUsersViewModelNavigationSercvice;
        private readonly UserStore _userStore;
        private readonly IUsersManagerService _usersManagerService;

        public DeleteUserCommand(SearchUserViewModel searchUserViewModel, NavigationService manageUsersViewModelNavigationSercvice, UserStore userStore,
            IUsersManagerService usersManagerService)
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
                _usersManagerService.DeleteUser(_userStore.User.Name);
                
                _manageUsersViewModelNavigationSercvice.Navigate();
            }
        }

    }
}
