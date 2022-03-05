using AccountManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Stores;
using System.ComponentModel;

namespace AccountManager.ViewModels
{
    internal class SearchUserViewModel : ViewModelBase
    {
        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        private string _searchResult;
        public string SearchResult
        {
            get => _searchResult;
            set
            {
                _searchResult = value;
                OnPropertyChanged(nameof(SearchResult));
            }
        }

        private readonly IUsersManagerService _usersManagerModel;
        private readonly UserStore _userStore;

        public ICommand SearchUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand CancelCommand { get; }

        public SearchUserViewModel(NavigationService userManagerViewNavigationService, NavigationService editUserViewModelNavigationService, 
            IUsersManagerService usersManagerService, UserStore userStore)
        {
            _usersManagerModel = usersManagerService;
            _userStore = userStore;
            _userStore.Clear();

            _userStore.CurrentUserChanged += ChangeSearchResult;

            EditUserCommand = new NavigateToEditCommand(editUserViewModelNavigationService, _userStore, _usersManagerModel);

            CancelCommand = new NavigateCommand(userManagerViewNavigationService);

            SearchUserCommand = new SearchUserCommand(this, usersManagerService, _userStore);

            DeleteUserCommand = new DeleteUserCommand(this, userManagerViewNavigationService, _userStore, usersManagerService);
        }

        private void ChangeSearchResult(object? sender, EventArgs e)
        {
            if (_userStore.User?.Name == null) SearchResult = "";
            else SearchResult = _userStore.User.Name;
        }
    }
}
