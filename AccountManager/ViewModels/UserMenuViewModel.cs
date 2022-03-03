using AccountManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;

namespace AccountManager.ViewModels
{
    internal class UserMenuViewModel : ViewModelBase
    {
        public ICommand ManageUsersCommand { get; }
        public ICommand ExitCommand { get; }

        public UserMenuViewModel(NavigationService manageUsersViewNavigationService)
        {
            ManageUsersCommand = new NavigateCommand(manageUsersViewNavigationService);

            ExitCommand = new ExitCommand();
        }
    }
}
