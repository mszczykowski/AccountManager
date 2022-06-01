using ShopWPF.Stores;
using System.Windows.Input;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.UserManagerCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;
using ShopWPF.ViewModels.ManageUsersViewModels;

namespace ShopWPF.ViewModels
{
    internal class EditUserViewModel : UserFormViewModel
    {
        public ICommand EditUserCommand { get; }

        private readonly UserStore _userStore;

        public EditUserViewModel(NavigationService<SearchUserViewModel> searchUserViewNavigationService, 
            IUserManagerService usersManagerService, UserStore userStore) : base(searchUserViewNavigationService)
        {
            _userStore = userStore;

            Username = userStore.User.Name;
            Password = userStore.User.Password;

            EditUserCommand = new EditUserCommand(this, searchUserViewNavigationService, 
                usersManagerService, userStore);
            
            
            
        }
    }
}
