﻿using System;
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
    internal class UserOrderViewModel : ViewModelBase
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

        public UserOrderViewModel(OrderModel order, IOrderManagerService orderManagerService)
        {
            _order = order;

            Name = "Order_" + _order.Id;

            TotalPrice = CalculateTotalPrice().ToString("N2");

            _status = _order.Status;

            upddateOrderStatusCommand = new UpdateOrderStatusCommand(this, orderManagerService);


        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            
            foreach(var p in _order.Products)
            {
                total += p.Price * p.Quantity;
            }

            return total;
        }

    }
}
