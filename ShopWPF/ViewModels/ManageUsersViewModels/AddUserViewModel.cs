using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.UserManagerCommands;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using System.Windows.Input;

namespace ShopWPF.ViewModels
{
    internal class AddUserViewModel : ViewModelBase
    {

        public ICommand AddUserCommand { get; }

        public AddUserViewModel(NavigationService<ManageUsersViewModel> userManagerViewNavigationService, IUserManagerService usersManagerService)
        {
            AddUserCommand = new AddUserCommand(userManagerViewNavigationService, this, usersManagerService);

        }
    }
}
