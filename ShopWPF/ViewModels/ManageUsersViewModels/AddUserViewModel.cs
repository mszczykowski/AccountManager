using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.UserManagerCommands;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.ViewModels.ManageUsersViewModels;
using System.Windows.Input;

namespace ShopWPF.ViewModels
{
    internal class AddUserViewModel : UserFormViewModel
    {

        public ICommand AddUserCommand { get; }

        public AddUserViewModel(NavigationService<ManageUsersViewModel> userManagerViewNavigationService, IUserManagerService usersManagerService)
            :base(userManagerViewNavigationService)
        {
            AddUserCommand = new AddUserCommand(userManagerViewNavigationService, this, usersManagerService);

        }
    }
}
