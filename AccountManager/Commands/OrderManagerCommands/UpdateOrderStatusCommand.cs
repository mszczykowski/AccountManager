using AccountManager.Enums;
using AccountManager.Services;
using AccountManager.ViewModels.ManageOrdersViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountManager.Commands.OrderManagerCommands
{
    internal class UpdateOrderStatusCommand : CommandBase
    {
        private readonly IProductsManagerService _productManager;
        private readonly IOrderManagerService _orderManager;

        private ManageUserOrderDetailsViewModel _manageUserOrderDetailViewModel;
        public UpdateOrderStatusCommand(ManageUserOrderDetailsViewModel manageUserOrderDetailViewModel,
            IProductsManagerService productManager, IOrderManagerService orderManager)
        {
            _productManager = productManager;
            _orderManager = orderManager;
            _manageUserOrderDetailViewModel = manageUserOrderDetailViewModel;


            _manageUserOrderDetailViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if((e.PropertyName == nameof(ManageUserOrderDetailsViewModel.OrderStatus))) OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return _manageUserOrderDetailViewModel.OrderStatus != _manageUserOrderDetailViewModel.Order.Status
                && _manageUserOrderDetailViewModel.Order.Status != OrderStatuses.Canceled && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_manageUserOrderDetailViewModel.OrderStatus == OrderStatuses.Canceled)
            {
                if (MessageBox.Show("Cancel order?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _orderManager.UpdateStatus(_manageUserOrderDetailViewModel.Order.Id, OrderStatuses.Canceled);

                    _manageUserOrderDetailViewModel.Order.Products.ToList().ForEach(p =>
                    {
                        _productManager.ReduceProductQantity(p.ProductId, -p.Quantity);
                    });
                }
            }

            else
            {
                _orderManager.UpdateStatus(_manageUserOrderDetailViewModel.Order.Id, _manageUserOrderDetailViewModel.OrderStatus);
            }

            _manageUserOrderDetailViewModel.Order.Status = _manageUserOrderDetailViewModel.OrderStatus;

            OnCanExecuteChanged();
        }
    }
}
