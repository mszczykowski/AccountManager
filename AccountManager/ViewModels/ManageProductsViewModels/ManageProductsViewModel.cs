using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Services;
using AccountManager.Commands;
using AccountManager.Commands.ProductManagerCommands;
using AccountManager.Models;
using AccountManager.Enums;
using AccountManager.Stores;

namespace AccountManager.ViewModels
{
    internal class ManageProductsViewModel : ViewModelBase
    {
        private readonly IProductsManagerService _productManagerService;
        public ICommand BackCommand { get; }

        public ICommand FilterProductsCommand { get; }

        public ICommand AddProductCommand { get; }

        public ICommand EditProductCommand { get; }

        public ICommand ClearAllFiltersCommand { get; }

        public ICommand DeleteSelectedCommand { get; private set; }

        private ObservableCollection<ProductViewModel> _products;

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

        public ManageProductsViewModel(NavigationService adminMenuViewModelNavigationService, NavigationService addProductViewModelNavigationService,
            NavigationService editProductViewModelNavigationService, IProductsManagerService productManagerService, ProductStore productStore)
        {
            BackCommand = new NavigateCommand(adminMenuViewModelNavigationService);

            FilterProductsCommand = new FilterProductsCommand(this);

            AddProductCommand = new NavigateCommand(addProductViewModelNavigationService);

            EditProductCommand = new NavigateToEditProductCommand(productStore, editProductViewModelNavigationService);

            ClearAllFiltersCommand = new ClearAllFiltersCommand(this);


            _productManagerService = productManagerService;

            _products = new ObservableCollection<ProductViewModel>();
            

            InitialiseCategoriesList();

            UpdateProductsCollection();

            DeleteSelectedCommand = new DeleteSelectedCommand(this, _productManagerService);
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
