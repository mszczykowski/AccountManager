using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AccountManager.ViewModels;
using AccountManager.Stores;
using AccountManager.Services;
using AccountManager.Models;
using AccountManager.Context;


namespace AccountManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly DataContext _dataContext;
        private readonly UserStore _userStore;

        public App()
        {
            _navigationStore = new NavigationStore();

            _dataContext = new DataContext();

            _userStore = new UserStore();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMainMenuViewModel();
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(new NavigationService(_navigationStore, CreateLogInViewModel));
        }

        private LogInViewModel CreateLogInViewModel()
        {
            return new LogInViewModel(new NavigationService(_navigationStore, CreateMainMenuViewModel), 
                new NavigationService(_navigationStore, CreateUserMenuViewModel), 
                new UsersManagerService(_dataContext));
        }

        private UserMenuViewModel CreateUserMenuViewModel()
        {
            return new UserMenuViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new NavigationService(_navigationStore, CreateManageProductsViewModel),
                new NavigationService(_navigationStore, CreateLogInViewModel));
        }

        private ManageUsersViewModel CreateManageUsersViewModel()
        {
            return new ManageUsersViewModel(new NavigationService(_navigationStore, CreateAddUserViewModel), 
                new NavigationService(_navigationStore, CreateUserMenuViewModel),
                new NavigationService(_navigationStore, CreateSearchUserViewModel),
                new UsersManagerService(_dataContext));
        }

        private AddUserViewModel CreateAddUserViewModel()
        {
            return new AddUserViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new UsersManagerService(_dataContext));
        }

        private EditUserViewModel CreateEditUserViewModel()
        {
            return new EditUserViewModel(new NavigationService(_navigationStore, CreateSearchUserViewModel),
                new UsersManagerService(_dataContext),
                _userStore);
        }

        private SearchUserViewModel CreateSearchUserViewModel()
        {
            return new SearchUserViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new NavigationService(_navigationStore, CreateEditUserViewModel),
                new UsersManagerService(_dataContext),
                _userStore);
        }

        private ManageProductsViewModel CreateManageProductsViewModel()
        {
            return new ManageProductsViewModel(new NavigationService(_navigationStore, CreateUserMenuViewModel),
                new ProductManagerService(_dataContext));
        }
    }
}
