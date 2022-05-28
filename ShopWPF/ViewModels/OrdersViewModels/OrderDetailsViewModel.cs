using ShopWPF.Commands.MisicCommands;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Enums;
using ShopWPF.Models;
using ShopWPF.Services;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ProductsViewModels;
using ShopWPF.ViewModels.UserViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.OrdersViewModels
{
    internal abstract class OrderDetailsViewModel : ViewModelBase
    {
        protected readonly OrderModel _order;

        public OrderModel Order => _order;

        private readonly IProductsManagerService _productManagerService;

        public string OrderName => _order.Name;

        protected ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;

        public ICommand BackCommand { get; protected set; }

        
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

        public OrderDetailsViewModel(IProductsManagerService productManagerService, OrderStore orderStrore, 
            IOrderManagerService orderManagerService)
        {
            _order = orderStrore.Order;

            _productManagerService = productManagerService;

            InitialiseProductsList();

            

            
        }

        private void InitialiseProductsList()
        {
            _products = new ObservableCollection<ProductViewModel>();

            _order.Products.ToList().ForEach(p =>
            {
                var product = _productManagerService.GetProductIncludingDeleted(p.ProductId);
                var totalPrice = p.Price * p.Quantity;
                _products.Add(new ProductViewModel(new ProductModel(product.Name,
                    totalPrice, p.Quantity, product.Category)));
            });
        }
    }
}
