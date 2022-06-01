using ShopWPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ShopWPF.Commands.ShopCommands.ShoppingCartCommands;
using System.ComponentModel;
using ShopWPF.Commands.ShopCommands;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Models.Discounts;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels.ShopViewModels
{
    internal class ShoppingCartViewModel : ViewModelBase
    {
        private LoggedUserStore _loggedUserStore;

        private readonly IProductManagerService _productsManagerService;

        private ObservableCollection<ShoppingCartEntryViewModel> _shoppingCartEntries;

        private readonly IShoppingCartService _shoppingCartDatabaseService;

        private readonly IDiscountManagerService _discountManagerService;

        public IEnumerable<ShoppingCartEntryViewModel> ShoppingCartEntries => _shoppingCartEntries;

        private ObservableCollection<DiscountViewModel> _discountsViewModels;

        public IEnumerable<DiscountViewModel> DiscountsViewModels => _discountsViewModels;

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

        private string _fullPriceWithDiscounts;

        public string FullPriceWithDiscounts
        {
            get => _fullPriceWithDiscounts;
            set
            {
                _fullPriceWithDiscounts = value;
                OnPropertyChanged(nameof(FullPriceWithDiscounts));
            }
        }

        private ICollection<DiscountBaseModel> discountsCache;

        public ShoppingCartViewModel(NavigationService<ProductsShopViewModel> productShopViewNavigationService, 
            LoggedUserStore loggedUserStore, IProductManagerService productsManagerService, 
            IOrderManagerService orderManagerService,
            IShoppingCartService shoppingCartDatabaseService,
            IShopService shopService,
            IDiscountManagerService discountManagerService)
        {
            _loggedUserStore = loggedUserStore;

            _productsManagerService = productsManagerService;

            _shoppingCartEntries = new ObservableCollection<ShoppingCartEntryViewModel>();

            _discountsViewModels = new ObservableCollection<DiscountViewModel>();

            ClearCartCommand = new ClearCartCommand(this, shoppingCartDatabaseService, _loggedUserStore);

            BackCommand = new NavigateCommand<ProductsShopViewModel>(productShopViewNavigationService);

            PlaceOrderCommand = new PlaceOrderCommand(_loggedUserStore, 
                productShopViewNavigationService, shopService, this);

            _shoppingCartDatabaseService = shoppingCartDatabaseService;

            _discountManagerService = discountManagerService;

            UpdateShoppingCartEntries();

            UpdateView();

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
            if (e.PropertyName == nameof(ShoppingCartEntryViewModel.ActualQuantity))
            {
                UpdateView();

                var updatedEntry = sender as ShoppingCartEntryViewModel;

                _shoppingCartDatabaseService.UpdateProductQuantity(_loggedUserStore.User.UserId, updatedEntry.ProductModel.ProductId, updatedEntry.ActualQuantity);
            }
        }

        public void UpdateView()
        {
            CalculateFullPrice();
            UpdateDiscountValues();
            CalculateFullPriceWithDiscounts();
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

        public async void UpdateShoppingCartEntries()
        {
            if(discountsCache == null) discountsCache = await _discountManagerService.GetDiscounts();

            _shoppingCartEntries.Clear();

            _loggedUserStore.User.ShoppingCart.ToList().ForEach(async entry =>
            {
                _shoppingCartEntries.Add(new ShoppingCartEntryViewModel(await _productsManagerService
                    .GetProduct(entry.Product.ProductId), entry));
            });

            OnPropertyChanged(nameof(ShoppingCartEntries));
        }

        private void UpdateDiscountValues()
        {
            _discountsViewModels.Clear();

            discountsCache.ToList().ForEach(discount =>
            {
                _discountsViewModels.Add(new DiscountViewModel(discount.ToString(), discount.GetDiscountValue(_loggedUserStore.User.ShoppingCart).ToString("N2")));
            });
        }

        private void CalculateFullPriceWithDiscounts()
        {
            double fullPrice = 0;

            _shoppingCartEntries.ToList<ShoppingCartEntryViewModel>().ForEach(entry =>
            {
                fullPrice += entry.ProductModel.Price * entry.ActualQuantity;
            });

            discountsCache.ToList().ForEach(discount =>
            {
                fullPrice -= discount.GetDiscountValue(_loggedUserStore.User.ShoppingCart);
            });

            FullPriceWithDiscounts = fullPrice.ToString("N2");
        }

        
    }
}
