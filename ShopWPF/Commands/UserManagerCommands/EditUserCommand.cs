using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.ViewModels;
using ShopWPF.Models;
using System.Windows;
using ShopWPF.Services;
using ShopWPF.Stores;


namespace ShopWPF.Commands.UserManagerCommands
{
    internal class EditUserCommand : CommandBase
    {
        private readonly EditUserViewModel _editUserViewModel;
        private readonly NavigationService<SearchUserViewModel> _searchUserViewModelNavigationSercvice;
        private readonly UserStore _userStore;
        private readonly IUserManagerService _usersManagerService;

        public EditUserCommand(EditUserViewModel editUserViewModel, 
            NavigationService<SearchUserViewModel> searchUserViewModelNavigationSercvice,
                IUserManagerService usersManagerService, UserStore userStore)
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
                _usersManagerService.EditUser(_userStore.User.UserId, new StandardUserModel(_editUserViewModel.Username, _editUserViewModel.Password));

                MessageBox.Show("User edited");
                _searchUserViewModelNavigationSercvice.Navigate();
            }
            

        }
    }
}
