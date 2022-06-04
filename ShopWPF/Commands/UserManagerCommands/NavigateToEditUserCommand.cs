/*using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using ShopWPF.ViewModels;
using System;

namespace ShopWPF.Commands.UserManagerCommands
{
    internal class NavigateToEditUserCommand : CommandBase
    {
        private readonly NavigationService<EditUserViewModel> _editUserViewModelNavigationSercvice;
        private readonly UserStore _userStore;
        private readonly IUserManagerService _usersManagerService;

        public NavigateToEditUserCommand(NavigationService<EditUserViewModel> editUserViewModelNavigationSercvice,
            UserStore userStore, IUserManagerService usersManagerService)
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
}*/