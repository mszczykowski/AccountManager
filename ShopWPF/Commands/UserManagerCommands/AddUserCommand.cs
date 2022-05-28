using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.ViewModels;
using ShopWPF.Models;
using System.Windows;
using ShopWPF.Services;
using System.ComponentModel;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class AddUserCommand : CommandBase
    {
        private readonly NavigationService<ManageUsersViewModel> _manageUsersViewNavigationService;
        private readonly AddUserViewModel _addEditViewModel;
        private readonly IUserManagerService _usersManagerService;


        public AddUserCommand(NavigationService<ManageUsersViewModel> manageUsersViewNavigationService, 
            AddUserViewModel addEditViewModel, IUserManagerService usersManagerService)
        {
            _manageUsersViewNavigationService = manageUsersViewNavigationService;
            _addEditViewModel = addEditViewModel;
            _usersManagerService = usersManagerService;
            _addEditViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addEditViewModel.Username) && !string.IsNullOrEmpty(_addEditViewModel.Password)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(_addEditViewModel.Username) && string.IsNullOrEmpty(_addEditViewModel.Password)) MessageBox.Show("Enter username and password!");
            
            if (_usersManagerService.GetUser(_addEditViewModel.Username) != null) MessageBox.Show("Username already used!");

            else
            {
                _usersManagerService.AddStandardUser(new StandardUserModel(_addEditViewModel.Username, _addEditViewModel.Password));
                _addEditViewModel.ClearFields();
                MessageBox.Show("User created");
                _manageUsersViewNavigationService.Navigate();
            }
        }
    }
}
