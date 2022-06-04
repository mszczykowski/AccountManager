using ShopWPF.Stores;
using System.Windows.Input;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.UserManagerCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;
using ShopWPF.ViewModels.ManageUsersViewModels;
using ShopWPF.Models;
using ShopWPF.ViewModels.ManageOrdersViewModels;

namespace ShopWPF.ViewModels
{
    internal class EditUserViewModel : UserFormViewModel
    {
        private UserModel _userModel;
        public UserModel User 
        { 
            get => _userModel; 
            set => _userModel = value; 
        }

        public ICommand EditUserCommand { get; }

        public ICommand ViewOrdersCommand { get; }

        public ICommand DeleteUserCommand { get; }

        public EditUserViewModel(NavigationService<ManageUsersViewModel> manageUsersViewNavigationService, 
            IUserManagerService usersManagerService, IdStore idStore,
            NavigationService<ManageUserOrdersViewModel> manageUserOrdersViewNavigationService) : base(manageUsersViewNavigationService)
        {
            LoadUser(idStore.Id, usersManagerService);

            DeleteUserCommand = new DeleteUserCommand(this, manageUsersViewNavigationService, usersManagerService);

            EditUserCommand = new EditUserCommand(this, usersManagerService);

            idStore.Id = _userModel.UserId;

            ViewOrdersCommand = new NavigateCommand<ManageUserOrdersViewModel>(manageUserOrdersViewNavigationService);
        }

        private async void LoadUser(int id, IUserManagerService userManagerService)
        {
            var user = await userManagerService.GetUser(id);

            User = user;
            Username = user.Name;
            Password = user.Password;
        }
    }
}
