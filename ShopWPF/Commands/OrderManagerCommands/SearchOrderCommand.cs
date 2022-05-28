using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using ShopWPF.ViewModels.OrdersViewModels;

namespace ShopWPF.Commands.OrderManagerCommands
{
    internal class SearchOrderCommand : CommandBase
    {
        private OrdersListViewModel _ordersListViewModel;
        public SearchOrderCommand(OrdersListViewModel ordersListViewModel)
        {
            _ordersListViewModel = ordersListViewModel;
        }


        public override void Execute(object? parameter)
        {
            _ordersListViewModel.UpdateOrdersCollection();
        }
    }
}
