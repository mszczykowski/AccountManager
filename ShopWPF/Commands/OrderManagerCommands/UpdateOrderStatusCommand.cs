using ShopWPF.Enums;
using ShopWPF.Services.Interfaces;
using ShopWPF.ViewModels.ManageOrdersViewModels;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ShopWPF.Commands.OrderManagerCommands
{
    internal class UpdateOrderStatusCommand : CommandBase
    {
        private readonly IOrderManagerService _orderManager;
        private readonly IShopService _shopService;
        private ManageUserOrderDetailsViewModel _orderViewModel;
        public UpdateOrderStatusCommand(ManageUserOrderDetailsViewModel orderViewModel,
            IOrderManagerService orderManager, IShopService shopService)
        {
            _orderManager = orderManager;
            _shopService = shopService;
            _orderViewModel = orderViewModel;

            _orderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if((e.PropertyName == nameof(ManageUserOrderDetailsViewModel.OrderStatus))) OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (int)_orderViewModel.OrderStatus != _orderViewModel.Order.StatusId
                && _orderViewModel.Order.StatusId != (int)OrderStatuses.Canceled && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            if (_orderViewModel.OrderStatus == OrderStatuses.Canceled)
            {
                if (MessageBox.Show("Cancel order?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;

                await _shopService.CancelOrder(_orderViewModel.Order);
            }

            else
            {
                await _orderManager.UpdateStatus(_orderViewModel.Order.OrderId, 
                    _orderViewModel.OrderStatus);
            }

            _orderViewModel.Order.StatusId = (int)_orderViewModel.OrderStatus;

            OnCanExecuteChanged();
        }
    }
}
