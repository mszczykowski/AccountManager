using AccountManager.Commands;
using AccountManager.Services;
using AccountManager.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Commands.ShopCommands.ShoppingCartCommands;
using System.ComponentModel;
using AccountManager.Commands.ShopCommands;

namespace AccountManager.ViewModels.ShopViewModels
{
    internal class ShoppingCartViewModel : ViewModelBase
    {
        private LoggedUserStore _loggedUserStore;

        private IProductsManagerService _productsManagerService;

        private ObservableCollection<ShoppingCartEntryViewModel> _shoppingCartEntries;

        public IEnumerable<ShoppingCartEntryViewModel> ShoppingCartEntries => _shoppingCartEntries;

        public ICommand BackCommand { get; }

        public ICommand ClearCartCommand { get; }

        public ICommand PlaceOrderCommand { get; }

        private string _fullprice;

        public string FullPrice 
        { 
            get => _fullprice; 
            set
            {
                _fullprice = value;
                OnPropertyChanged(nameof(FullPrice));
            }
        }

        public ShoppingCartViewModel(NavigationService productShopViewNavigationService, 
            LoggedUserStore loggedUserStore, IProductsManagerService productsManagerService, IOrderManagerService orderManagerService)
        {
            _loggedUserStore = loggedUserStore;

            _productsManagerService = productsManagerService;

            _shoppingCartEntries = new ObservableCollection<ShoppingCartEntryViewModel>();

            ClearCartCommand = new ClearCartCommand(this, _loggedUserStore.User.ShoppingCart);

            BackCommand = new NavigateCommand(productShopViewNavigationService);

            PlaceOrderCommand = new PlaceOrderCommand(this, _loggedUserStore, productsManagerService, orderManagerService, productShopViewNavigationService);

            UpdateShoppingCartEnetries();

            SetPropertyChangeListeners();

            
        }

        private void SetPropertyChangeListeners()
        {
            _shoppingCartEntries.ToList<ShoppingCartEntryViewModel>().ForEach(entry =>
           {
               entry.PropertyChanged += OnViewModelPropertyChanged;
           });
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShoppingCartEntryViewModel.ActualQuantity)) CalculateFullPrice();
        }

        private void CalculateFullPrice()
        {
            double fullPrice = 0;

            _shoppingCartEntries.ToList<ShoppingCartEntryViewModel>().ForEach(entry =>
            {
                fullPrice += entry.ProductModel.Price * entry.ActualQuantity;
            });

            FullPrice = fullPrice.ToString("N2");
        }

        public void UpdateShoppingCartEnetries()
        {
            _shoppingCartEntries.Clear();

            _loggedUserStore.User.ShoppingCart.ToList().ForEach(entry =>
            {
                _shoppingCartEntries.Add(new ShoppingCartEntryViewModel(_productsManagerService.GetProduct(entry.Product.Id), entry));
            });

            OnPropertyChanged(nameof(ShoppingCartEntries));

            CalculateFullPrice();
        }
    }
}
