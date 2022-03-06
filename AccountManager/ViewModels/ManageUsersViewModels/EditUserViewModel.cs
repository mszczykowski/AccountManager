using AccountManager.Commands;
using AccountManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;
using System.ComponentModel;
using AccountManager.Models;
using AccountManager.Stores;

namespace AccountManager.ViewModels
{
    internal class EditUserViewModel : ViewModelBase
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

        private readonly UserStore _userStore;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand EditUserCommand { get; }
        public ICommand CancelCommand { get; }

        public EditUserViewModel(NavigationService searchUserViewNavigationService, IUsersManagerService usersManagerService, UserStore userStore)
        {
            _userStore = userStore;

            _userName = userStore.User.Name;
            _password = userStore.User.Password;

            CancelCommand = new NavigateCommand(searchUserViewNavigationService);

            EditUserCommand = new EditUserCommand(this, searchUserViewNavigationService, 
                usersManagerService, userStore);
            
            
            
        }
    }
}
