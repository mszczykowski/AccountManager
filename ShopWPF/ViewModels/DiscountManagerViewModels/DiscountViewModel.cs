using ShopWPF.Commands.DiscountCommands;
using ShopWPF.Discounts;
using ShopWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.DiscountManagerViewModels
{
    internal class DiscountViewModel : ViewModelBase
    {
        private readonly DiscountBaseModel _discount;

        public string DiscountDescription { get; }

        public ICommand DeleteDiscountCommand { get; }

        public DiscountViewModel(DiscountManagerViewModel discountManagerViewModel, DiscountBaseModel discount, DiscountManager discountManager,
            IDiscountManagerService discountsDatabaseService)
        {
            _discount = discount;

            DiscountDescription = _discount.ToString();

            DeleteDiscountCommand = new DeleteDiscountCommand(discountManagerViewModel, discountManager, discount, discountsDatabaseService);
        }
    }
}
