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
    internal class EditUserCommand : CommandBase
    {
        private readonly EditUserViewModel _editUserViewModel;
        private readonly NavigationService _searchUserViewModelNavigationSercvice;
        private readonly UserStore _userStore;
        private readonly IUsersManagerService _usersManagerService;

        public EditUserCommand(EditUserViewModel editUserViewModel, NavigationService searchUserViewModelNavigationSercvice,
                IUsersManagerService usersManagerService, UserStore userStore)
        {
            _searchUserViewModelNavigationSercvice = searchUserViewModelNavigationSercvice;
            _userStore = userStore;
            _usersManagerService = usersManagerService;
            _editUserViewModel = editUserViewModel;

            _editUserViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_editUserViewModel.Username) && !string.IsNullOrEmpty(_editUserViewModel.Password)
                && base.CanExecute(parameter);
        }


        public override void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(_editUserViewModel.Username) && string.IsNullOrEmpty(_editUserViewModel.Password)) MessageBox.Show("Enter username and password!");

            if (_usersManagerService.GetUser(_editUserViewModel.Username) != null) MessageBox.Show("Username already used!");

            else
            {
                _usersManagerService.EditUser(_userStore.User.Name, new StandarUser(_editUserViewModel.Username, _editUserViewModel.Password));

                MessageBox.Show("User edited");
                _searchUserViewModelNavigationSercvice.Navigate();
            }
            

        }
    }
}
