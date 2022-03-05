using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels;
using AccountManager.Models;
using System.Windows;
using AccountManager.Services;
using System.ComponentModel;

namespace AccountManager.Commands
{
    internal class AddUserCommand : CommandBase
    {
        private readonly AddUserViewModel _addEditViewModel;
        private readonly IUsersManagerService _usersManagerService;


        public AddUserCommand(AddUserViewModel addEditViewModel, IUsersManagerService usersManagerService)
        {
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
                _usersManagerService.AddUser(new StandardUserModel(_addEditViewModel.Username, _addEditViewModel.Password));
                _addEditViewModel.ClearFields();
                MessageBox.Show("User created");
            }
        }
    }
}
