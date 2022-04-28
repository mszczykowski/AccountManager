using AccountManager.Discounts;
using AccountManager.Services;
using AccountManager.ViewModels.DiscountManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Enums;

namespace AccountManager.Commands.DiscountCommands
{
    internal class AddDiscountCommand : CommandBase
    {
        private readonly AddDiscountViewModel _addDiscountViewModel;
        private readonly DiscountManager _discountManager;
        private readonly NavigationService<DiscountManagerViewModel> _discountManagerViewNavigationService;
        private readonly IDiscountsManagerService _discountDatabaseService;

        public AddDiscountCommand(AddDiscountViewModel addDiscountViewModel, DiscountManager discountManager,
            NavigationService<DiscountManagerViewModel> discountManagerViewNavigationService,
            IDiscountsManagerService discountDatabaseService)
        {
            _addDiscountViewModel = addDiscountViewModel;
            _discountManager = discountManager;
            _discountManagerViewNavigationService = discountManagerViewNavigationService;
            _discountDatabaseService = discountDatabaseService;
        }

        public override void Execute(object? parameter)
        {
            switch(_addDiscountViewModel.DiscountType)
            {
                case (DiscountTypes.Category_discount):
                    AddCategoryDiscount();
                    break;
                case (DiscountTypes.Product_discount):
                    AddProductDiscount();
                    break;
                case (DiscountTypes.Total_price_discount):
                    AddTotalPriceDiscount();
                    break;
            }

            _discountManagerViewNavigationService.Navigate();
        }

        public void AddCategoryDiscount()
        {
            var id = _discountDatabaseService.AddCategoryDiscount((int)DiscountTypes.Category_discount, _addDiscountViewModel.Category);
            _discountManager.AddDiscount(new FiftyPercentOffOnCategorySecondProduct(id, _addDiscountViewModel.Category));
        }

        public void AddProductDiscount()
        {
            var id = _discountDatabaseService.AddProductDiscount((int)DiscountTypes.Product_discount, _addDiscountViewModel.Product);
            _discountManager.AddDiscount(new ThirtyPercentOffProdcut(id, _addDiscountViewModel.Product));
        }

        public void AddTotalPriceDiscount()
        {
            var id = _discountDatabaseService.AddOtherDiscount((int)DiscountTypes.Total_price_discount);
            _discountManager.AddDiscount(new TenEveryHundredDiscount(id));
        }
    }
}
