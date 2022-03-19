using AccountManager.Commands;
using AccountManager.Commands.MisicCommands;
using AccountManager.Discounts;
using AccountManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.DiscountManagerViewModels
{
    internal class DiscountManagerViewModel : ViewModelBase
    {
        public ICommand BackCommand { get; }
        public ICommand AddDicountCommand { get; }

        private ObservableCollection<DiscountViewModel> _discounts;

        public IEnumerable<DiscountViewModel> DiscountsViewModels => _discounts;

        private readonly DiscountManager _discountManager;

        public DiscountManagerViewModel(DiscountManager discountManager, NavigationService adminMenuViewNavigationService, 
            NavigationService addDiscountViewNavigationService)
        {
            _discountManager = discountManager;

            BackCommand = new NavigateCommand(adminMenuViewNavigationService);

            AddDicountCommand = new NavigateCommand(addDiscountViewNavigationService);

            _discounts = new ObservableCollection<DiscountViewModel>();

            UpdateDiscountsList();
        }

        public void UpdateDiscountsList()
        {
            _discounts.Clear();

            _discountManager.Discounts.ToList().ForEach(discount =>
            {
                _discounts.Add(new DiscountViewModel(this, discount, _discountManager));
            });
        }
    }
}
