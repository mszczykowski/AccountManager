using ShopWPF.Models;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ProductsViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ShopWPF.ViewModels.OrdersViewModels
{
    internal abstract class OrderDetailsViewModel : ViewModelBase
    {
        private readonly IProductManagerService _productManagerService;
        private readonly IOrderManagerService _orderManagerService;

        protected OrderModel _order;

        public OrderModel Order => _order;

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

        public OrderDetailsViewModel(IProductManagerService productManagerService, IdStore idStore, 
            IOrderManagerService orderManagerService)
        {
            _productManagerService = productManagerService;
            _orderManagerService = orderManagerService;

            InitialiseOrder(idStore.Id);
            InitialiseProductsList();
        }

        private async void InitialiseOrder(int id)
        {
            _order = await _orderManagerService.GetOrder(id);
        }

        private void InitialiseProductsList()
        {
            _products = new ObservableCollection<ProductViewModel>();

            _order.Products.ToList().ForEach(async p =>
            {
                var product = await _productManagerService.GetProductIncludingDeleted(p.ProductId);
                var totalPrice = p.Price * p.Quantity;
                _products.Add(new ProductViewModel(new ProductModel(product.Name,
                    totalPrice, p.Quantity, product.Category)));
            });
        }
    }
}
