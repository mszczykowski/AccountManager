using System.ComponentModel;
using ShopWPF.ViewModels;
using System.Windows;
using ShopWPF.Stores;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class EditUserCommand : CommandBase
    {
        private readonly EditUserViewModel _userViewModel;
        private readonly IUserManagerService _usersManagerService;

        public EditUserCommand(EditUserViewModel userViewModel,
                IUserManagerService usersManagerService)
        {
            _usersManagerService = usersManagerService;
            _userViewModel = userViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(_userViewModel.Username) && string.IsNullOrEmpty(_userViewModel.Password)) MessageBox.Show("Enter username and password!");

            if (_usersManagerService.GetUser(_userViewModel.Username) != null) MessageBox.Show("Username already used!");

            else
            {
                _usersManagerService.EditUser(_userViewModel.User.UserId, new UserModel
                {
                    Name = _userViewModel.Username,
                    Password = _userViewModel.Password,
                    UserRole = Enums.UserRoles.Standard
                });

                MessageBox.Show("User edited");
            }
            

        }
    }
}
