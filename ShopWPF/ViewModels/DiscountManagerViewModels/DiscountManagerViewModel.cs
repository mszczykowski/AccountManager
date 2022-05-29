using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services;
using ShopWPF.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ShopWPF.ViewModels.DiscountManagerViewModels
{
    internal class DiscountManagerViewModel : ViewModelBase
    {
        public ICommand BackCommand { get; }
        public ICommand AddDicountCommand { get; }

        private ObservableCollection<DiscountViewModel> _discounts;

        public IEnumerable<DiscountViewModel> DiscountsViewModels => _discounts;


        private readonly IDiscountManagerService _discountsDatabaseService;

        public DiscountManagerViewModel(NavigationService<AdminMenuViewModel> adminMenuViewNavigationService, 
            NavigationService<AddDiscountViewModel> addDiscountViewNavigationService,
            IDiscountManagerService discountsDatabaseService)
        {

            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewNavigationService);

            AddDicountCommand = new NavigateCommand<AddDiscountViewModel>(addDiscountViewNavigationService);

            _discounts = new ObservableCollection<DiscountViewModel>();

            _discountsDatabaseService = discountsDatabaseService;

            UpdateDiscountsList();
        }

        public async void UpdateDiscountsList()
        {
            _discounts.Clear();

            var discounts = await _discountsDatabaseService.GetDiscounts();

            discounts.ToList().ForEach(discount =>
            {
                _discounts.Add(new DiscountViewModel(this, discount, _discountsDatabaseService));
            });
        }
    }
}
