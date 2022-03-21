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
using AccountManager.Commands.UserManagerCommands;
using AccountManager.Commands.MisicCommands;
using AccountManager.ViewModels.ManageOrdersViewModels;

namespace AccountManager.ViewModels
{
    internal class ManageUsersViewModel : ViewModelBase
    {
        private readonly IUsersManagerService _usersManagerService;
        public ICommand AddUserCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand NavigateToUserOrdersCommand { get; }


        private readonly ObservableCollection<UserViewModel> _users;

        public IEnumerable<UserViewModel> Users => _users;

        public ManageUsersViewModel(NavigationService<AddUserViewModel> addUserViewNavigationService, 
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService,
            NavigationService<SearchUserViewModel> searchViewNavigationService, 
            NavigationService<ManageUserOrdersViewModel> manageUserOrdersViewNavigationService,
            IUsersManagerService usersManagerService, UserStore userStore)
        {
            AddUserCommand = new NavigateCommand<AddUserViewModel>(addUserViewNavigationService);

            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewNavigationService);

            SearchCommand = new NavigateCommand<SearchUserViewModel>(searchViewNavigationService);

            NavigateToUserOrdersCommand = new NavigateToUserOrdersCommand(userStore, manageUserOrdersViewNavigationService);

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
