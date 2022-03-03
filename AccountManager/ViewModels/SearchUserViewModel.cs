using AccountManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Commands;


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

        public ICommand SearchUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand CancelCommand { get; }

        public SearchUserViewModel(NavigationService userManagerViewNavigationService, NavigationService addEditViewNavigationService, IUsersManagerService usersManagerModel)
        {
            CancelCommand = new NavigateCommand(userManagerViewNavigationService);


            _usersManagerModel = usersManagerModel;

            SearchUserCommand = new SearchUserCommand(this, usersManagerModel);
        }
    }
}
