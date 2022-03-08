using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels.ManageOrdersViewModels;

namespace AccountManager.Commands.OrderManagerCommands
{
    internal class SearchOrderCommand : CommandBase
    {
        private ManageUserOrdersViewModel _manageUserOrdersViewModel;
        public SearchOrderCommand(ManageUserOrdersViewModel manageUserOrdersViewModel)
        {
            _manageUserOrdersViewModel = manageUserOrdersViewModel;
        }


        public override void Execute(object? parameter)
        {
            _manageUserOrdersViewModel.UpdateOrdersCollection();
        }
    }
}
