using System;
using ShopWPF.Models;
using ShopWPF.Enums;
using System.Windows.Input;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.ViewModels.ManageOrdersViewModels
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

            Name = "Order_" + _order.OrderId;

            TotalPrice = _order.TotalPrice.ToString("N2");

            _status = (OrderStatuses)_order.StatusId;
        }

    }
}
