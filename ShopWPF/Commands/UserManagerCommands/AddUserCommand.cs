using ShopWPF.ViewModels;
using System.Windows;
using System.ComponentModel;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;
using ShopWPF.Models;

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
                _usersManagerService.AddStandardUser(new UserModel
                {
                    Name = _addEditViewModel.Username,
                    Password = _addEditViewModel.Password,
                    UserRole = Enums.UserRoles.Standard
                });
                _addEditViewModel.ClearFields();
                MessageBox.Show("User created");
                _manageUsersViewNavigationService.Navigate();
            }
        }
    }
}
