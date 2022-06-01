using ShopWPF.Services;
using ShopWPF.ViewModels.DiscountManagerViewModels;
using ShopWPF.Enums;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.Commands.DiscountCommands
{
    internal class AddDiscountCommand : CommandBase
    {
        private readonly AddDiscountViewModel _addDiscountViewModel;
        private readonly NavigationService<DiscountManagerViewModel> _discountManagerViewNavigationService;
        private readonly IDiscountManagerService _discountDatabaseService;

        public AddDiscountCommand(AddDiscountViewModel addDiscountViewModel,
            NavigationService<DiscountManagerViewModel> discountManagerViewNavigationService,
            IDiscountManagerService discountDatabaseService)
        {
            _addDiscountViewModel = addDiscountViewModel;
            _discountManagerViewNavigationService = discountManagerViewNavigationService;
            _discountDatabaseService = discountDatabaseService;
        }

        public override void Execute(object? parameter)
        {
            switch(_addDiscountViewModel.DiscountType)
            {
                case (DiscountTypes.Category_discount):
                    _discountDatabaseService.AddDiscount(_addDiscountViewModel.Category);
                    break;
                case (DiscountTypes.Product_discount):
                    _discountDatabaseService.AddDiscount(_addDiscountViewModel.Product);
                    break;
                case (DiscountTypes.Total_price_discount):
                    _discountDatabaseService.AddDiscount();
                    break;
            }

            _discountManagerViewNavigationService.Navigate();
        }
    }
}
