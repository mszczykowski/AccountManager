using AccountManager.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.ViewModels.ShopViewModels
{
    internal class DiscountViewModel : ViewModelBase
    {
        private readonly DiscountBase discountBase;

        private string _discountDescription;
        public string DiscountDescription 
        { 
            get => _discountDescription; 
            set
            {
                _discountDescription = value;
                OnPropertyChanged(nameof(DiscountDescription));
            }
        }

        private string _discountValue;


        public string DiscountValue
        {
            get => _discountValue;
            set
            {
                _discountValue = value;
                OnPropertyChanged(nameof(DiscountValue));
            }
        }

        public DiscountViewModel(string discountDescription, string discountValue)
        {
            _discountDescription = discountDescription + ": ";
            _discountValue = "- " + discountValue;
        }

    }
}
