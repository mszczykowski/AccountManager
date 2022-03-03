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

namespace AccountManager.ViewModels
{
    internal class LogInViewModel : ViewModelBase
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
        private readonly UsersManagerModel _usersManagerModel;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LogInCommand { get; }
        public ICommand CancelCommand { get; }

        public LogInViewModel(NavigationService mainMenuViewNavigationService, UsersManagerModel usersManagerModel)
        {
            CancelCommand = new NavigateCommand(mainMenuViewNavigationService);

            
            _usersManagerModel = usersManagerModel;

            LogInCommand = new LogInCommand(this, _usersManagerModel);
        }

    }
}
