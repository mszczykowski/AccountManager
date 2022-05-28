using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Commands;
using ShopWPF.Commands.DiscountCommands;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Discounts;
using ShopWPF.Enums;
using ShopWPF.Models;
using ShopWPF.Services;

namespace ShopWPF.ViewModels.DiscountManagerViewModels
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
            NavigationService<DiscountManagerViewModel> discountManagerViewNavigationService, IDiscountManagerService discountsDatabaseService)
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
