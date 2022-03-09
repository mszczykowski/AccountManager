using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Stores;
using AccountManager.Services;
using AccountManager.Commands.UserManagerCommands;
using System.Collections.ObjectModel;
using AccountManager.Commands.ProductManagerCommands;
using AccountManager.Enums;

namespace AccountManager.ViewModels.ProductsViewModels
{
    internal class ProductsListViewModel : ViewModelBase
    {
        protected readonly IProductsManagerService _productManagerService;
        public ICommand BackCommand { get; }

        public ICommand FilterProductsCommand { get; }

        public ICommand ClearAllFiltersCommand { get; }

        protected ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;

        private CategoryModel _category;

        public CategoryModel Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private string _search;

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        private List<CategoryModel> _categoriesList;

        public List<CategoryModel> CategoriesList { get => _categoriesList; }

        public ProductsListViewModel(NavigationService adminMenuViewModelNavigationService,
            IProductsManagerService productManagerService)
        {
            BackCommand = new NavigateCommand(adminMenuViewModelNavigationService);

            FilterProductsCommand = new FilterProductsCommand(this);


            ClearAllFiltersCommand = new ClearAllFiltersCommand(this);


            _productManagerService = productManagerService;

            _products = new ObservableCollection<ProductViewModel>();


            InitialiseCategoriesList();

            UpdateProductsCollection();
        }

        public void UpdateProductsCollection()
        {
            IEnumerable<ProductModel> filteredProducts;

            if (_category == null || _category.Id == -1) filteredProducts = _productManagerService.GetFilteredProducts(_search, null);
            else filteredProducts = _productManagerService.GetFilteredProducts(_search, (Categories)_category.Id);

            _products.Clear();
            foreach (var product in filteredProducts)
            {
                _products.Add(new ProductViewModel(product));
            }
        }

        public void InitialiseCategoriesList()
        {
            _categoriesList = new List<CategoryModel>
            {
                new CategoryModel(-1, "All categories")

            };

            foreach (var cat in Enum.GetValues(typeof(Categories)))
            {
                _categoriesList.Add(new CategoryModel((int)cat, cat.ToString()));
            }
        }
    }
}
