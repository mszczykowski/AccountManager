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
        private readonly IProductManagerService _productManager;
        private readonly IOrderManagerService _orderManager;

        private ManageUserOrderDetailsViewModel _manageUserOrderDetailViewModel;
        public UpdateOrderStatusCommand(ManageUserOrderDetailsViewModel manageUserOrderDetailViewModel,
            IProductManagerService productManager, IOrderManagerService orderManager)
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
            return (int)_manageUserOrderDetailViewModel.OrderStatus != _manageUserOrderDetailViewModel.Order.StatusId
                && _manageUserOrderDetailViewModel.Order.StatusId != (int)OrderStatuses.Canceled && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_manageUserOrderDetailViewModel.OrderStatus == OrderStatuses.Canceled)
            {
                if (MessageBox.Show("Cancel order?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _orderManager.UpdateStatus(_manageUserOrderDetailViewModel.Order.OrderId, OrderStatuses.Canceled);

                    _manageUserOrderDetailViewModel.Order.Products.ToList().ForEach(p =>
                    {
                        _productManager.ChangeQuantity(p.ProductId, p.Product.Quantity + p.Quantity);
                    });
                }
            }

            else
            {
                _orderManager.UpdateStatus(_manageUserOrderDetailViewModel.Order.OrderId, _manageUserOrderDetailViewModel.OrderStatus);
            }

            _manageUserOrderDetailViewModel.Order.StatusId = (int)_manageUserOrderDetailViewModel.OrderStatus;

            OnCanExecuteChanged();
        }
    }
}
