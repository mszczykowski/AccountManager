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

        public override async void Execute(object? parameter)
        {
            _userViewModel.ValidateForm();

            if (_userViewModel.HasErrors) return;

            var user = await _usersManagerService.GetUser(_userViewModel.Username);

            if (user != null && user.UserId != _userViewModel.User.UserId) MessageBox.Show("Username already used!");

            else
            {
                await _usersManagerService.EditUser(_userViewModel.User.UserId, new UserModel
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
