using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Commands.DiscountCommands;
using AccountManager.Commands.MisicCommands;
using AccountManager.Discounts;
using AccountManager.Enums;
using AccountManager.Models;
using AccountManager.Services;

namespace AccountManager.ViewModels.DiscountManagerViewModels
{
    internal class AddDiscountViewModel : ViewModelBase
    {
        public DiscountTypes DiscountType { get; set; }
        public Categories Category { get; set; }

        public ProductModel Product {  get; set; }

        private ICollection<ProductModel> _productsCollection;
        
        public ICollection<ProductModel> ProductsCollection { get => _productsCollection; }

        private readonly IProductsManagerService _productsManagerService;

        public ICommand AddDiscountCommand { get; }

        public ICommand CancelCommand { get; }

        public AddDiscountViewModel(IProductsManagerService productsManagerService, DiscountManager discountManager, 
            NavigationService<DiscountManagerViewModel> discountManagerViewNavigationService, IDiscountsDatabaseService discountsDatabaseService)
        {

            _productsManagerService = productsManagerService;

            AddDiscountCommand = new AddDiscountCommand(this, discountManager, discountManagerViewNavigationService, discountsDatabaseService);

            CancelCommand = new NavigateCommand<DiscountManagerViewModel>(discountManagerViewNavigationService);

            InitialiseProductsCollection();
        }

        private void InitialiseProductsCollection()
        {

            _productsCollection = _productsManagerService.GetAllProducts();
        }
    }
}
