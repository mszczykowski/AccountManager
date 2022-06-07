using System.Collections.Generic;
using System.Windows.Input;
using ShopWPF.Commands.DiscountCommands;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Enums;
using ShopWPF.Models;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.ViewModels.DiscountManagerViewModels
{
    internal class AddDiscountViewModel : ViewModelBase
    {
        public DiscountTypes DiscountType { get; set; }
        public CategoryModel Category { get; set; }

        private ICollection<CategoryModel> _categories;

        public ICollection<CategoryModel> Categories { get => _categories; }

        public ProductModel Product {  get; set; }

        private ICollection<ProductModel> _productsCollection;
        
        public ICollection<ProductModel> ProductsCollection { get => _productsCollection; }

        private readonly IProductManagerService _productsManagerService;

        private readonly ICategoryManagerService _categoryManagerService;

        public ICommand AddDiscountCommand { get; }

        public ICommand CancelCommand { get; }

        public AddDiscountViewModel(IProductManagerService productsManagerService, 
            NavigationService<DiscountManagerViewModel> discountManagerViewNavigationService, 
            IDiscountManagerService discountsDatabaseService,
            ICategoryManagerService categoryManagerService)
        {

            _productsManagerService = productsManagerService;
            _categoryManagerService = categoryManagerService;

            AddDiscountCommand = new AddDiscountCommand(this, discountManagerViewNavigationService, discountsDatabaseService);

            CancelCommand = new NavigateCommand<DiscountManagerViewModel>(discountManagerViewNavigationService);

            Initialise();
        }

        private async void Initialise()
        {
            _productsCollection = await _productsManagerService.GetAllProducts();
            _categories = await _categoryManagerService.GetAllCategories();

            DiscountType = DiscountTypes.Total_price_discount;
        }
    }
}
