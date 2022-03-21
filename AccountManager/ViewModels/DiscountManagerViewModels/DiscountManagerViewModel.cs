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

        private readonly IDiscountsDatabaseService _discountsDatabaseService;

        public DiscountManagerViewModel(DiscountManager discountManager, 
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService, 
            NavigationService<AddDiscountViewModel> addDiscountViewNavigationService,
            IDiscountsDatabaseService discountsDatabaseService)
        {
            _discountManager = discountManager;

            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewNavigationService);

            AddDicountCommand = new NavigateCommand<AddDiscountViewModel>(addDiscountViewNavigationService);

            _discounts = new ObservableCollection<DiscountViewModel>();

            _discountsDatabaseService = discountsDatabaseService;

            UpdateDiscountsList();
        }

        public void UpdateDiscountsList()
        {
            _discounts.Clear();

            _discountManager.Discounts.ToList().ForEach(discount =>
            {
                _discounts.Add(new DiscountViewModel(this, discount, _discountManager, _discountsDatabaseService));
            });
        }
    }
}
