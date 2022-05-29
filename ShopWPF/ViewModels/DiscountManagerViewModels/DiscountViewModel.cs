using ShopWPF.Commands.DiscountCommands;
using ShopWPF.Models.Discounts;
using ShopWPF.Services.Interfaces;
using System.Windows.Input;

namespace ShopWPF.ViewModels.DiscountManagerViewModels
{
    internal class DiscountViewModel : ViewModelBase
    {
        private readonly DiscountBaseModel _discount;

        public string DiscountDescription { get; }

        public ICommand DeleteDiscountCommand { get; }

        public DiscountViewModel(DiscountManagerViewModel discountManagerViewModel, DiscountBaseModel discount,
            IDiscountManagerService discountsDatabaseService)
        {
            _discount = discount;

            DiscountDescription = _discount.ToString();

            DeleteDiscountCommand = new DeleteDiscountCommand(discountManagerViewModel, discount, 
                discountsDatabaseService);
        }
    }
}
