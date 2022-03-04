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

namespace AccountManager.Commands
{
    internal class LogInCommand : CommandBase
    {
        private readonly LogInViewModel _logInViewModel;
        private readonly IUsersManagerService _usersManagerService;
        private readonly NavigationService _userMenuViewModelNavigationService;

        public LogInCommand(LogInViewModel logInViewModel, IUsersManagerService usersManagerService, NavigationService userMenuViewModelNavigationService)
        {
            _logInViewModel = logInViewModel;
            _usersManagerService = usersManagerService;
            _userMenuViewModelNavigationService = userMenuViewModelNavigationService;
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
            
            if(user == null) MessageBox.Show("User not found");

            else if (!user.IsPasswordValid(_logInViewModel.Password)) MessageBox.Show("Password incorrect!");

            else if (!user.HasAdminPermission()) MessageBox.Show("Insufficient permission!");
            
            else _userMenuViewModelNavigationService.Navigate();



        }
    }
}
