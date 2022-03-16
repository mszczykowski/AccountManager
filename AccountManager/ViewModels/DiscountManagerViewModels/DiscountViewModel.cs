using AccountManager.Commands.DiscountCommands;
using AccountManager.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.DiscountManagerViewModels
{
    internal class DiscountViewModel : ViewModelBase
    {
        private readonly DiscountBase _discount;

        public string DiscountDescription { get; }

        public ICommand DeleteDiscountCommand { get; }

        public DiscountViewModel(DiscountManagerViewModel discountManagerViewModel, DiscountBase discount, DiscountManager discountManager)
        {
            _discount = discount;

            DiscountDescription = _discount.ToString();

            DeleteDiscountCommand = new DeleteDiscountCommand(discountManagerViewModel, discountManager, discount);
        }
    }
}
