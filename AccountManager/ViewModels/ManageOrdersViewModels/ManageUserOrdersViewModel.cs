using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;
using AccountManager.Commands;
using AccountManager.Commands.ProductManagerCommands;
using AccountManager.Models;
using AccountManager.Commands.OrderManagerCommands;
using AccountManager.Stores;
using System.Collections.ObjectModel;
using AccountManager.Commands.OrderManagerCommands;

namespace AccountManager.ViewModels.ManageOrdersViewModels
{
    internal class ManageUserOrdersViewModel : ViewModelBase
    {
        private readonly IOrderManagerService _orderManagerService;

        private UserStore _customer;
        
        public ICommand BackCommand { get; }

        public ICommand SearchOrderCommand { get; }

        private ICommand UpdateOrderStatusCommand { get; }

        private ObservableCollection<UserOrderViewModel> _orders;

        public IEnumerable<UserOrderViewModel> Orders => _orders;

        public string CustomerName => _customer.User.Name;


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

        public ManageUserOrdersViewModel(NavigationService ManageUsersViewNavigationService, IOrderManagerService orderManagerService, UserStore customer)
        {
            _customer = customer;

            _orderManagerService = orderManagerService;

            _orders = new ObservableCollection<UserOrderViewModel>();

            BackCommand = new NavigateCommand(ManageUsersViewNavigationService);

            SearchOrderCommand = new SearchOrderCommand(this);

            UpdateOrdersCollection();
        }

        public void UpdateOrdersCollection()
        {
            _orders.Clear();
            
            var orders = _orderManagerService.GetUserOrders(_customer.User.Id);

            foreach(var order in orders)
            {
                if(String.IsNullOrEmpty(Query)) _orders.Add(new UserOrderViewModel(order, _orderManagerService));
                else
                {
                    if(("Order_" + order.Id).ToUpper() == Query.ToUpper()) _orders.Add(new UserOrderViewModel(order, _orderManagerService));
                }


            }
        }
    }
}
