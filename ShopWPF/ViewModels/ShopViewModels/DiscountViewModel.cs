﻿using ShopWPF.Models.Discounts;

namespace ShopWPF.ViewModels.ShopViewModels
{
    internal class DiscountViewModel : ViewModelBase
    {
        private readonly DiscountBaseModel discountBase;

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
