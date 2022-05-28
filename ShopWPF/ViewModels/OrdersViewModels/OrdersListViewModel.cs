using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Services;
using ShopWPF.Commands;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Models;
using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels.OrdersViewModels
{
    internal abstract class OrdersListViewModel : ViewModelBase
    {
        protected readonly IOrderManagerService _orderManagerService;

        protected UserModel _customer;

        public ICommand BackCommand { get; protected set; }

        public ICommand SearchOrderCommand { get; }

        public ICommand OrderOnClickCommand { get; protected set; }


        protected ObservableCollection<OrderViewModel> _orders;

        public IEnumerable<OrderViewModel> Orders => _orders;



        private string _query;

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        public OrdersListViewModel(IOrderManagerService orderManagerService)
        {
            _orderManagerService = orderManagerService;

            _orders = new ObservableCollection<OrderViewModel>();


            SearchOrderCommand = new SearchOrderCommand(this);
        }

        public void UpdateOrdersCollection()
        {
            _orders.Clear();

            var orders = _orderManagerService.GetUserOrders(_customer.UserId);

            foreach (var order in orders)
            {
                if (String.IsNullOrEmpty(Query)) _orders.Add(new OrderViewModel(order, _orderManagerService));
                else
                {
                    if (("Order_" + order.Id).ToUpper() == Query.ToUpper()) _orders.Add(new OrderViewModel(order, _orderManagerService));
                }


            }
        }
    }
}
