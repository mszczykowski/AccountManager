using ShopWPF.Models.Discounts;
using ShopWPF.Services.Interfaces;
using ShopWPF.ViewModels.DiscountManagerViewModels;
using System.Windows;

namespace ShopWPF.Commands.DiscountCommands
{
    internal class DeleteDiscountCommand : CommandBase
    {
        private readonly DiscountManagerViewModel _discountManagerViewModel;
        private readonly DiscountBaseModel _discount;
        private readonly IDiscountManagerService _discountsDatabaseService;

        public DeleteDiscountCommand(DiscountManagerViewModel discountManagerViewModel, DiscountBaseModel discount,
            IDiscountManagerService discountsDatabaseService)
        {
            _discountManagerViewModel = discountManagerViewModel;
            _discount = discount;
            _discountsDatabaseService = discountsDatabaseService;
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Delete \"" + _discount.ToString() + "\" ?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _discountsDatabaseService.DeleteDiscount(_discount.DiscountId);

                _discountManagerViewModel.UpdateDiscountsList();
            }
        }
    }
}
