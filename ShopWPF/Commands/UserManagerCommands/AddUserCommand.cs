using ShopWPF.ViewModels;
using System.Windows;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;
using ShopWPF.Models;
using ShopWPF.ViewModels.ManageUsersViewModels;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class AddUserCommand : CommandBase
    {
        private readonly NavigationService<ManageUsersViewModel> _manageUsersViewNavigationService;
        private readonly AddUserViewModel _userFormViewModel;
        private readonly IUserManagerService _usersManagerService;


        public AddUserCommand(NavigationService<ManageUsersViewModel> manageUsersViewNavigationService,
            AddUserViewModel userFormViewModel, IUserManagerService usersManagerService)
        {
            _manageUsersViewNavigationService = manageUsersViewNavigationService;
            _userFormViewModel = userFormViewModel;
            _usersManagerService = usersManagerService;
        }

        public async override void Execute(object? parameter)
        {
            _userFormViewModel.ValidateForm();

            if (_userFormViewModel.HasErrors) return;

            if (await _usersManagerService.GetUser(_userFormViewModel.Username) != null) MessageBox.Show("Username already used!");

            else
            {
                await _usersManagerService.AddStandardUser(new UserModel
                {
                    Name = _userFormViewModel.Username,
                    Password = _userFormViewModel.Password,
                    UserRole = Enums.UserRoles.Standard
                });
                MessageBox.Show("User created");
                _manageUsersViewNavigationService.Navigate();
            }
        }
    }
}
