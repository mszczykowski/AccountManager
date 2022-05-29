using System;
using System.Windows;
using ShopWPF.ViewModels;
using ShopWPF.Stores;
using ShopWPF.Services;
using ShopWPF.Data;
using ShopWPF.ViewModels.ManageProductsViewModels;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.ViewModels.ShopViewModels;
using ShopWPF.ViewModels.UserViews;
using ShopWPF.ViewModels.DiscountManagerViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopWPF.Services.ShopServices;
using ShopWPF.Services.Interfaces;

namespace ShopWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                services.AddDbContext<ShopDBContext>(options => options.UseSqlite("Data Source=Scheduler.db"));
                services.AddScoped<IUserManagerService, UserManagerService>();
                services.AddScoped<IProductManagerService, ProductManagerService>();
                services.AddScoped<IOrderManagerService, OrderManagerService>();
                services.AddScoped<IDiscountManagerService, DiscountManagerService>();
                services.AddScoped<IShoppingCartService, ShoppingCartService>();
                services.AddScoped<IShopService, ShopService>();
                services.AddScoped<ICategoryManagerService, CategoryManagerService>();

                services.AddSingleton<UserStore>();
                services.AddSingleton<ProductStore>();
                services.AddSingleton<OrderStore>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<LoggedUserStore>();

                services.AddTransient<MainMenuViewModel>();
                services.AddSingleton<Func<MainMenuViewModel>>((s) => () => s.GetRequiredService<MainMenuViewModel>());
                services.AddSingleton<NavigationService<MainMenuViewModel>>();

                services.AddTransient<LogInViewModel>();
                services.AddSingleton<Func<LogInViewModel>>((s) => () => s.GetRequiredService<LogInViewModel>());
                services.AddSingleton<NavigationService<LogInViewModel>>();

                services.AddTransient<AdminMenuViewModel>();
                services.AddSingleton<Func<AdminMenuViewModel>>((s) => () => s.GetRequiredService<AdminMenuViewModel>());
                services.AddSingleton<NavigationService<AdminMenuViewModel>>();

                services.AddTransient<ManageUsersViewModel>();
                services.AddSingleton<Func<ManageUsersViewModel>>((s) => () => s.GetRequiredService<ManageUsersViewModel>());
                services.AddSingleton<NavigationService<ManageUsersViewModel>>();

                services.AddTransient<AddUserViewModel>();
                services.AddSingleton<Func<AddUserViewModel>>((s) => () => s.GetRequiredService<AddUserViewModel>());
                services.AddSingleton<NavigationService<AddUserViewModel>>();

                services.AddTransient<EditUserViewModel>();
                services.AddSingleton<Func<EditUserViewModel>>((s) => () => s.GetRequiredService<EditUserViewModel>());
                services.AddSingleton<NavigationService<EditUserViewModel>>();

                services.AddTransient<SearchUserViewModel>();
                services.AddSingleton<Func<SearchUserViewModel>>((s) => () => s.GetRequiredService<SearchUserViewModel>());
                services.AddSingleton<NavigationService<SearchUserViewModel>>();

                services.AddTransient<ManageProductsViewModel>();
                services.AddSingleton<Func<ManageProductsViewModel>>((s) => () => s.GetRequiredService<ManageProductsViewModel>());
                services.AddSingleton<NavigationService<ManageProductsViewModel>>();


                services.AddTransient<AddProductViewModel>();
                services.AddSingleton<Func<AddProductViewModel>>((s) => () => s.GetRequiredService<AddProductViewModel>());
                services.AddSingleton<NavigationService<AddProductViewModel>>();

                services.AddTransient<EditProductViewModel>();
                services.AddSingleton<Func<EditProductViewModel>>((s) => () => s.GetRequiredService<EditProductViewModel>());
                services.AddSingleton<NavigationService<EditProductViewModel>>();

                services.AddTransient<UserMenuViewModel>();
                services.AddSingleton<Func<UserMenuViewModel>>((s) => () => s.GetRequiredService<UserMenuViewModel>());
                services.AddSingleton<NavigationService<UserMenuViewModel>>();

                services.AddTransient<ManageUserOrdersViewModel>();
                services.AddSingleton<Func<ManageUserOrdersViewModel>>((s) => () => s.GetRequiredService<ManageUserOrdersViewModel>());
                services.AddSingleton<NavigationService<ManageUserOrdersViewModel>>();

                services.AddTransient<ProductsShopViewModel>();
                services.AddSingleton<Func<ProductsShopViewModel>>((s) => () => s.GetRequiredService<ProductsShopViewModel>());
                services.AddSingleton<NavigationService<ProductsShopViewModel>>();

                services.AddTransient<ShoppingCartViewModel>();
                services.AddSingleton<Func<ShoppingCartViewModel>>((s) => () => s.GetRequiredService<ShoppingCartViewModel>());
                services.AddSingleton<NavigationService<ShoppingCartViewModel>>();

                services.AddTransient<UserOrdersViewModel>();
                services.AddSingleton<Func<UserOrdersViewModel>>((s) => () => s.GetRequiredService<UserOrdersViewModel>());
                services.AddSingleton<NavigationService<UserOrdersViewModel>>();

                services.AddTransient<DiscountManagerViewModel>();
                services.AddSingleton<Func<DiscountManagerViewModel>>((s) => () => s.GetRequiredService<DiscountManagerViewModel>());
                services.AddSingleton<NavigationService<DiscountManagerViewModel>>();

                services.AddTransient<AddDiscountViewModel>();
                services.AddSingleton<Func<AddDiscountViewModel>>((s) => () => s.GetRequiredService<AddDiscountViewModel>());
                services.AddSingleton<NavigationService<AddDiscountViewModel>>();

                services.AddTransient<UserOrderDetailsViewModel>();
                services.AddSingleton<Func<UserOrderDetailsViewModel>>((s) => () => s.GetRequiredService<UserOrderDetailsViewModel>());
                services.AddSingleton<NavigationService<UserOrderDetailsViewModel>>();

                services.AddTransient<ManageUserOrderDetailsViewModel>();
                services.AddSingleton<Func<ManageUserOrderDetailsViewModel>>((s) => () => s.GetRequiredService<ManageUserOrderDetailsViewModel>());
                services.AddSingleton<NavigationService<ManageUserOrderDetailsViewModel>>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });

            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            NavigationService<MainMenuViewModel> navigationService 
                = _host.Services.GetRequiredService<NavigationService<MainMenuViewModel>>();

            navigationService.Navigate();
            
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
