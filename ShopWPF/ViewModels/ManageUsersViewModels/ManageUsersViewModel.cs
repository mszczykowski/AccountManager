using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ShopWPF.Stores;
using ShopWPF.Services;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.ViewModels
{
    internal class ManageUsersViewModel : ViewModelBase
    {
        private readonly IUserManagerService _usersManagerService;
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
            IUserManagerService usersManagerService, UserStore userStore)
        {
            AddUserCommand = new NavigateCommand<AddUserViewModel>(addUserViewNavigationService);

            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewNavigationService);

            SearchCommand = new NavigateCommand<SearchUserViewModel>(searchViewNavigationService);

            NavigateToUserOrdersCommand = new NavigateToUserOrdersCommand(userStore, manageUserOrdersViewNavigationService);

            _users = new ObservableCollection<UserViewModel>();
            _usersManagerService = usersManagerService;

            UpdateUsersCollection();
        }

        private async void UpdateUsersCollection()
        {
            var users = await _usersManagerService.GetAllUsers();

            foreach (var u in users)
            {
                _users.Add(new UserViewModel(u));
            }
        }
    }
}
