using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;
using AccountManager.Commands.OrderManagerCommands;
using System.Windows.Input;
using AccountManager.Services;

namespace AccountManager.ViewModels.ManageOrdersViewModels
{
    internal class OrderViewModel : ViewModelBase
    {

        private OrderModel _order;

        public OrderModel Order
        {
            get => _order;
        }

        public string Name { get; }
        public string TotalPrice { get; }
        public DateTime OrderDate => _order.OrderDate;

        private ICommand upddateOrderStatusCommand;

        private OrderStatuses _status;
        public OrderStatuses Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public OrderViewModel(OrderModel order, IOrderManagerService orderManagerService)
        {
            _order = order;

            Name = "Order_" + _order.Id;

            TotalPrice = _order.TotalPrice.ToString("N2");

            _status = _order.Status;
        }

    }
}
