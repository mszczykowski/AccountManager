using ShopWPF.Commands;
using ShopWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Services;
using System.ComponentModel;
using ShopWPF.Models;
using ShopWPF.Stores;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.UserManagerCommands;

namespace ShopWPF.ViewModels
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

        public EditUserViewModel(NavigationService<SearchUserViewModel> searchUserViewNavigationService, 
            IUserManagerService usersManagerService, UserStore userStore)
        {
            _userStore = userStore;

            _userName = userStore.User.Name;
            _password = userStore.User.Password;

            CancelCommand = new NavigateCommand<SearchUserViewModel>(searchUserViewNavigationService);

            EditUserCommand = new EditUserCommand(this, searchUserViewNavigationService, 
                usersManagerService, userStore);
            
            
            
        }
    }
}
