using AccountManager.Commands;
using AccountManager.Commands.MisicCommands;
using AccountManager.Commands.UserManagerCommands;
using AccountManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels
{
    internal class AddUserViewModel : ViewModelBase
    {
        private string _userName;
        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        private readonly IUsersManagerService _usersManagerModel;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand CancelCommand { get; }

        public AddUserViewModel(NavigationService<ManageUsersViewModel> userManagerViewNavigationService, IUsersManagerService usersManagerService)
        {
            CancelCommand = new NavigateCommand<ManageUsersViewModel>(userManagerViewNavigationService);

            AddUserCommand = new AddUserCommand(userManagerViewNavigationService, this, usersManagerService);

        }

        public void ClearFields()
        {
            Username = "";
            Password = "";
        }
    }
}
