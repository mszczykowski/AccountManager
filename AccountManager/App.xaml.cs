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
using AccountManager.ViewModels.ManageProductsViewModels;
using AccountManager.ViewModels.ManageOrdersViewModels;


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
        private readonly ProductStore _productStore;

        public App()
        {
            _navigationStore = new NavigationStore();

            _dataContext = new DataContext();

            _userStore = new UserStore();

            _productStore = new ProductStore();
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
                new NavigationService(_navigationStore, CreateAdminMenuViewModel),
                new NavigationService(_navigationStore, CreateUserMenuViewModel), 
                new UsersManagerService(_dataContext));
        }

        private AdminMenuViewModel CreateAdminMenuViewModel()
        {
            return new AdminMenuViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new NavigationService(_navigationStore, CreateManageProductsViewModel),
                new NavigationService(_navigationStore, CreateLogInViewModel));
        }

        private ManageUsersViewModel CreateManageUsersViewModel()
        {
            return new ManageUsersViewModel(new NavigationService(_navigationStore, CreateAddUserViewModel), 
                new NavigationService(_navigationStore, CreateAdminMenuViewModel),
                new NavigationService(_navigationStore, CreateSearchUserViewModel),
                new NavigationService(_navigationStore, CreateManageUserOrdersViewModel),
                new UsersManagerService(_dataContext), _userStore);
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
            return new ManageProductsViewModel(new NavigationService(_navigationStore, CreateAdminMenuViewModel),
                new NavigationService(_navigationStore, CreateAddProductViewModel),
                new NavigationService(_navigationStore, CreateEditProductViewModel),
                new ProductsManagerService(_dataContext), _productStore);
        }

        private AddProductViewModel CreateAddProductViewModel()
        {
            return new AddProductViewModel(new NavigationService(_navigationStore, CreateManageProductsViewModel),
                new ProductsManagerService(_dataContext));
        }

        private EditProductViewModel CreateEditProductViewModel()
        {
            return new EditProductViewModel(new NavigationService(_navigationStore, CreateManageProductsViewModel),
                new ProductsManagerService(_dataContext), _productStore);
        }

        private UserMenuViewModel CreateUserMenuViewModel()
        {
            return new UserMenuViewModel(null, null, new NavigationService(_navigationStore, CreateLogInViewModel));
        }

        private ManageUserOrdersViewModel CreateManageUserOrdersViewModel()
        {
            return new ManageUserOrdersViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new OrderManagerService(_dataContext), _userStore);
        }
    }
}
