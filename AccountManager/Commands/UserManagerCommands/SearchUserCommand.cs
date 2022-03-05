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
    internal class SearchUserCommand : CommandBase
    {
        private readonly SearchUserViewModel _searchUserViewModel;
        private readonly IUsersManagerService _usersManagerService;
        private readonly UserStore _userStore;

        public SearchUserCommand(SearchUserViewModel searchUserViewModel, IUsersManagerService usersManagerService, UserStore userStore)
        {
            _searchUserViewModel = searchUserViewModel;
            _usersManagerService = usersManagerService;
            _userStore = userStore;
            _searchUserViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(SearchUserViewModel.Search))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_searchUserViewModel.Search) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var user = _usersManagerService.GetUser(_searchUserViewModel.Search);
            if (user == null)
            {
                _userStore.User = null;
                MessageBox.Show("User not found!");
            } 
            else
            {
                _userStore.User = user;
                MessageBox.Show("User found!");
            }
        }
    }
}
