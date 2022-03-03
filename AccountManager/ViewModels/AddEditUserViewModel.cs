using AccountManager.Commands;
using AccountManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels
{
    internal class AddEditUserViewModel : ViewModelBase
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

        public ICommand AddEditUserCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEditUserViewModel(NavigationService userManagerViewNavigationService, IUsersManagerService usersManagerService)
        {
            CancelCommand = new NavigateCommand(userManagerViewNavigationService);

            AddEditUserCommand = new AddUserCommand(this, usersManagerService);

        }

        public void ClearFields()
        {
            Username = "";
            Password = "";
        }
    }
}
