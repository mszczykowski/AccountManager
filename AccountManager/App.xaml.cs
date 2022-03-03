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

namespace AccountManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly UsersManagerModel _usersManagerModel;

        public App()
        {
            _navigationStore = new NavigationStore();

            _usersManagerModel = new UsersManagerModel();
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
            return new LogInViewModel(new NavigationService(_navigationStore, CreateMainMenuViewModel), _usersManagerModel);
        }
    }
}
