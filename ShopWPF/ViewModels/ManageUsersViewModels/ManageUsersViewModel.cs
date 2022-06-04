using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ShopWPF.Stores;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.Services.Interfaces;
using ShopWPF.Commands.UserManagerCommands;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels
{
    internal class ManageUsersViewModel : ViewModelBase
    {
        private readonly IUserManagerService _usersManagerService;
        public ICommand AddUserCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand NavigateToEditUserCommand { get; }


        private readonly ObservableCollection<UserViewModel> _users;

        public IEnumerable<UserViewModel> Users => _users;

        public ManageUsersViewModel(NavigationService<AddUserViewModel> addUserViewNavigationService, 
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService, 
            NavigationService<EditUserViewModel> editUserViewNavigationService,
            IUserManagerService usersManagerService, IdStore idStore)
        {
            AddUserCommand = new NavigateCommand<AddUserViewModel>(addUserViewNavigationService);

            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewNavigationService);

            NavigateToEditUserCommand = 
                new NaviagteAndStoreIdCommand<EditUserViewModel>(editUserViewNavigationService, idStore);

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
