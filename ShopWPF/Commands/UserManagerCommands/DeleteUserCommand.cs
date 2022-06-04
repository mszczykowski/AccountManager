using System;
using ShopWPF.ViewModels;
using System.Windows;
using ShopWPF.Stores;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class DeleteUserCommand : CommandBase
    {
        private readonly NavigationService<ManageUsersViewModel> _manageUsersViewModelNavigationSercvice;
        private readonly IUserManagerService _usersManagerService;
        private readonly EditUserViewModel _userViewModel;

        public DeleteUserCommand(EditUserViewModel userViewModel, 
            NavigationService<ManageUsersViewModel> manageUsersViewModelNavigationSercvice,
            IUserManagerService usersManagerService)
        {
            _manageUsersViewModelNavigationSercvice = manageUsersViewModelNavigationSercvice;
            _usersManagerService = usersManagerService;
            _userViewModel = userViewModel;
        }


        public override void Execute(object? parameter)
        {
            if (_userViewModel.User.UserRole == Enums.UserRoles.Admin)
            {
                MessageBox.Show("Can't delete admin account!");
                return;
            }
            
            if (MessageBox.Show("Delete user \"" + _userViewModel.User.Name + "\" ?", "Delete", MessageBoxButton.YesNo)
                == MessageBoxResult.No) return;

            _usersManagerService.DeleteUser(_userViewModel.User.UserId);

            _manageUsersViewModelNavigationSercvice.Navigate();
        }

    }
}
