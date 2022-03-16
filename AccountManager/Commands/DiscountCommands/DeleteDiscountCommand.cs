using AccountManager.Discounts;
using AccountManager.ViewModels.DiscountManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountManager.Commands.DiscountCommands
{
    internal class DeleteDiscountCommand : CommandBase
    {
        private readonly DiscountManagerViewModel _discountManagerViewModel;
        private readonly DiscountManager _discountManager;
        private readonly DiscountBase _discount;

        public DeleteDiscountCommand(DiscountManagerViewModel discountManagerViewModel, DiscountManager discountManager, DiscountBase discount)
        {
            _discountManagerViewModel = discountManagerViewModel;
            _discountManager = discountManager;
            _discount = discount;
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Delete \"" + _discount.ToString() + "\" ?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _discountManager.DeleteDiscount(_discount);

                _discountManagerViewModel.UpdateDiscountsList();
            }
        }
    }
}
