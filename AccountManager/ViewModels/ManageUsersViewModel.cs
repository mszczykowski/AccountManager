using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Stores;
using AccountManager.Services;

namespace AccountManager.ViewModels
{
    internal class ManageUsersViewModel : ViewModelBase
    {
        private readonly IUsersManagerService _usersManagerService;
        public ICommand AddUserCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand BackCommand { get; }

        private readonly ObservableCollection<UserViewModel> _users;

        public IEnumerable<UserViewModel> Users => _users;

        public ManageUsersViewModel(NavigationService addUserViewNavigationService, NavigationService userMenuViewNavigationService,
            NavigationService searchViewNavigationService, IUsersManagerService usersManagerService)
        {
            AddUserCommand = new NavigateCommand(addUserViewNavigationService);

            BackCommand = new NavigateCommand(userMenuViewNavigationService);

            SearchCommand = new NavigateCommand(searchViewNavigationService);

            _users = new ObservableCollection<UserViewModel>();
            _usersManagerService = usersManagerService;

            UpdateUsersCollection();
        }

        private void UpdateUsersCollection()
        {
            foreach (var u in _usersManagerService.GetAllUsers())
            {
                _users.Add(new UserViewModel(u));
            }
        }
    }
}
