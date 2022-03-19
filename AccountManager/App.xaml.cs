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
using AccountManager.ViewModels.ShopViewModels;
using AccountManager.ViewModels.UserViews;
using AccountManager.Discounts;
using AccountManager.ViewModels.DiscountManagerViewModels;
using Microsoft.Extensions.Hosting;

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
        private readonly LoggedUserStore _loggedUserStore;

        private readonly DiscountManager _discountManager;

        private readonly DatabaseConnection _databaseConnection;

        public App()
        {
            Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton
            })
            
            
            _navigationStore = new NavigationStore();

            _dataContext = new DataContext();

            _userStore = new UserStore();

            _productStore = new ProductStore();

            _loggedUserStore = new LoggedUserStore();

            _discountManager = DiscountManager.GetInstance();

            _databaseConnection = new DatabaseConnection();
            SqlTest();
        }

        private void SqlTest()
        {
            IUsersManagerService users = new UsersManagerDatabaseService(_databaseConnection);

            users.AddUser(new StandardUserModel("name", "password"));
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
                new UsersManagerService(_dataContext), _loggedUserStore);
        }

        private AdminMenuViewModel CreateAdminMenuViewModel()
        {
            return new AdminMenuViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new NavigationService(_navigationStore, CreateManageProductsViewModel),
                new NavigationService(_navigationStore, CreateLogInViewModel),
                new NavigationService(_navigationStore, CreateDiscountManagerViewModel));
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
            return new UserMenuViewModel(new NavigationService(_navigationStore, CreateProductsShopViewModel), 
                new NavigationService(_navigationStore, CreateUserOrdersViewModel), 
                new NavigationService(_navigationStore, CreateLogInViewModel));
        }

        private ManageUserOrdersViewModel CreateManageUserOrdersViewModel()
        {
            return new ManageUserOrdersViewModel(new NavigationService(_navigationStore, CreateManageUsersViewModel),
                new OrderManagerService(_dataContext), _userStore);
        }

        private ProductsShopViewModel CreateProductsShopViewModel()
        {
            return new ProductsShopViewModel(new NavigationService(_navigationStore, CreateUserMenuViewModel),
                new NavigationService(_navigationStore, CreateShoppingCartViewModel),
                new ProductsManagerService(_dataContext), _loggedUserStore);
        }

        private ShoppingCartViewModel CreateShoppingCartViewModel()
        {
            return new ShoppingCartViewModel(new NavigationService(_navigationStore, CreateProductsShopViewModel), _loggedUserStore, 
                new ProductsManagerService(_dataContext), new OrderManagerService(_dataContext));
        }

        private UserOrdersViewModel CreateUserOrdersViewModel()
        {
            return new UserOrdersViewModel(new NavigationService(_navigationStore, CreateUserMenuViewModel),
                new OrderManagerService(_dataContext), _loggedUserStore);
        }

        private DiscountManagerViewModel CreateDiscountManagerViewModel()
        {
            return new DiscountManagerViewModel(_discountManager,
                new NavigationService(_navigationStore, CreateAdminMenuViewModel),
                new NavigationService(_navigationStore, CreateAddDiscountViewModel));
        }

        private AddDiscountViewModel CreateAddDiscountViewModel()
        {
            return new AddDiscountViewModel(new ProductsManagerService(_dataContext), _discountManager,
                new NavigationService(_navigationStore, CreateDiscountManagerViewModel));
        }
    }
}
