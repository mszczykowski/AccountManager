using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels.ManageOrdersViewModels;
using AccountManager.Services;
using System.ComponentModel;

namespace AccountManager.Commands.OrderManagerCommands
{
    internal class UpdateOrderStatusCommand : CommandBase
    {
        private readonly UserOrderViewModel _userOrderViewModel;
        private readonly IOrderManagerService _orderManagerService;

        public UpdateOrderStatusCommand(UserOrderViewModel userOrderViewModel, IOrderManagerService orderManagerService)
        {
            _userOrderViewModel = userOrderViewModel;
            _orderManagerService = orderManagerService;

            _userOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserOrderViewModel.Status)) Execute(null);
        }

        public override void Execute(object? parameter)
        {
            _orderManagerService.UpdateStatus(_userOrderViewModel.Order.Id, _userOrderViewModel.Status);
        }
    }
}
