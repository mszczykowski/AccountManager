using System;
using System.Collections.Generic;
using ShopWPF.Commands.OrderManagerCommands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;

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

        public async void UpdateOrdersCollection()
        {
            _orders.Clear();

            var orders = await _orderManagerService.GetUserOrders(_customer.UserId);

            foreach (var order in orders)
            {
                if (String.IsNullOrEmpty(Query)) _orders.Add(new OrderViewModel(order, _orderManagerService));
                else
                {
                    if ((order.Name).ToUpper() == Query.ToUpper()) _orders.Add(new OrderViewModel(order, _orderManagerService));
                }


            }
        }
    }
}
