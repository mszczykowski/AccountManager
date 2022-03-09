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
using AccountManager.ViewModels.OrdersViewModels;
using System.ComponentModel;

namespace AccountManager.ViewModels.ManageOrdersViewModels
{
    internal class ManageUserOrdersViewModel : OrdersListViewModel
    {

        public string CustomerName => _customer.User.Name;



        public ManageUserOrdersViewModel(NavigationService ManageUsersViewNavigationService, IOrderManagerService orderManagerService, UserStore customer)
            : base(ManageUsersViewNavigationService, orderManagerService, customer)
        {
            SetOnPropertyChangedListener();
        }

        private void SetOnPropertyChangedListener()
        {
            _orders.ToList<OrderViewModel>().ForEach(order =>
            {
                order.PropertyChanged += OnViewModelPropertyChanged;
            });
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OrderViewModel.Status)) UpdateOrderStatus(sender);
        }

        private void UpdateOrderStatus(object? sender)
        {
            var order = sender as OrderViewModel;


            _orderManagerService.UpdateStatus(order.Order.Id, order.Status);
        }
    }
}
