using AccountManager.Commands.MisicCommands;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Enums;
using AccountManager.Models;
using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.ProductsViewModels;
using AccountManager.ViewModels.UserViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.OrdersViewModels
{
    internal abstract class OrderDetailsViewModel : ViewModelBase
    {
        private readonly OrderModel _order;

        public OrderModel Order => _order;

        private readonly IProductsManagerService _productManagerService;

        public string OrderName => _order.Name;

        protected ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;

        public ICommand BackCommand { get; set; }

        public ICommand CancelOrderCommand { get; set; }

        public string OrderStatus => _order.Status.ToString();

        public OrderStatuses OrderStausEnum => _order.Status;
        
        public string TotalPrice
        {
            get
            {
                return _order.TotalPrice.ToString("N2") + " PLN";
            }
        }

        public string DiscountValue
        {
            get
            {
                return _order.DiscountValue.ToString("N2") + " PLN";
            }
        }

        public OrderDetailsViewModel(IProductsManagerService productManagerService,
            NavigationService<UserOrdersViewModel> userOrdersViewNavigationService,
            OrderStore orderStrore, IOrderManagerService orderManagerService)
        {
            _order = orderStrore.Order;

            _productManagerService = productManagerService;

            InitialiseProductsList();

            BackCommand = new NavigateCommand<UserOrdersViewModel>(userOrdersViewNavigationService);

            CancelOrderCommand = new CancelOrderCommand(this, productManagerService, orderManagerService,
                userOrdersViewNavigationService);
        }

        private void InitialiseProductsList()
        {
            _products = new ObservableCollection<ProductViewModel>();

            _order.Products.ToList().ForEach(p =>
            {
                var product = _productManagerService.GetProduct(p.ProductId);
                var totalPrice = p.Price * p.Quantity;
                _products.Add(new ProductViewModel(new ProductModel(product.Name,
                    totalPrice, p.Quantity, product.Category)));
            });
        }
    }
}
