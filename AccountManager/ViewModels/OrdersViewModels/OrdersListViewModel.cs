using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Services;
using AccountManager.Commands;
using AccountManager.Commands.ProductManagerCommands;
using AccountManager.Models;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AccountManager.ViewModels.ManageOrdersViewModels;

namespace AccountManager.ViewModels.OrdersViewModels
{
    internal class OrdersListViewModel : ViewModelBase
    {
        protected readonly IOrderManagerService _orderManagerService;

        protected readonly UserStore _customer;

        public ICommand BackCommand { get; }

        public ICommand SearchOrderCommand { get; }


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

        public OrdersListViewModel(NavigationService ManageUsersViewNavigationService, IOrderManagerService orderManagerService, UserStore customer)
        {
            _customer = customer;

            _orderManagerService = orderManagerService;

            _orders = new ObservableCollection<OrderViewModel>();

            BackCommand = new NavigateCommand(ManageUsersViewNavigationService);

            SearchOrderCommand = new SearchOrderCommand(this);

            UpdateOrdersCollection();
        }

        public void UpdateOrdersCollection()
        {
            _orders.Clear();

            var orders = _orderManagerService.GetUserOrders(_customer.User.Id);

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
