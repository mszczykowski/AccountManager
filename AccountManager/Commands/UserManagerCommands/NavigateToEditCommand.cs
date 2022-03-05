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
    internal class NavigateToEditCommand : CommandBase
    {
        private readonly NavigationService _editUserViewModelNavigationSercvice;
        private readonly UserStore _userStore;
        private readonly IUsersManagerService _usersManagerService;

        public NavigateToEditCommand(NavigationService editUserViewModelNavigationSercvice, UserStore userStore,
            IUsersManagerService usersManagerService)
        {
            _editUserViewModelNavigationSercvice = editUserViewModelNavigationSercvice;
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
            return (_usersManagerService.GetUser(_userStore?.User?.Name) != null) && base.CanExecute(parameter);
        }


        public override void Execute(object? parameter)
        {
            _editUserViewModelNavigationSercvice.Navigate();
        }
    }
}
