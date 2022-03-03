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

        public App()
        {
            _navigationStore = new NavigationStore();

            _dataContext = new DataContext();
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
            return new UserMenuViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel));
        }

        private ManageUsersViewModel CreateManageUsersViewModel()
        {
            return new ManageUsersViewModel(new NavigationService(_navigationStore, CreateAddEditUserViewModel), 
                new NavigationService(_navigationStore, CreateLogInViewModel),
                new NavigationService(_navigationStore, CreateSearchUserViewModel),
                new UsersManagerService(_dataContext));
        }

        private AddEditUserViewModel CreateAddEditUserViewModel()
        {
            return new AddEditUserViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new UsersManagerService(_dataContext));
        }

        private SearchUserViewModel CreateSearchUserViewModel()
        {
            return new SearchUserViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new NavigationService(_navigationStore, CreateUserMenuViewModel),
                new UsersManagerService(_dataContext));
        }
    }
}
