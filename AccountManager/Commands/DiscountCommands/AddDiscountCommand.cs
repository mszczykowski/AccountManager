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
        private readonly NavigationService _discountManagerViewNavigationService;

        public AddDiscountCommand(AddDiscountViewModel addDiscountViewModel, DiscountManager discountManager, NavigationService discountManagerViewNavigationService)
        {
            _addDiscountViewModel = addDiscountViewModel;
            _discountManager = discountManager;
            _discountManagerViewNavigationService = discountManagerViewNavigationService;
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
            _discountManager.AddDiscount(new FiftyPercentOffOnCategorySecondProduct(_addDiscountViewModel.Category));
        }

        public void AddProductDiscount()
        {
            _discountManager.AddDiscount(new ThirtyPercentOffProdcut(_addDiscountViewModel.Product));
        }

        public void AddTotalPriceDiscount()
        {
            _discountManager.AddDiscount(new TenEveryHundredDiscount());
        }
    }
}
