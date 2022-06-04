using System;
using System.Collections.Generic;
using System.Linq;
using ShopWPF.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Services.Interfaces;

namespace ShopWPF.ViewModels.ProductsViewModels
{
    internal class ProductsListViewModel : ViewModelBase
    {
        protected readonly IProductManagerService _productManagerService;
        private readonly ICategoryManagerService _categoryManagerService;

        public ICommand BackCommand { get; set; }

        public ICommand FilterProductsCommand { get; }

        public ICommand ClearAllFiltersCommand { get; }

        private ICollection<ProductModel> productsCache;

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

        private string _query;

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        private List<CategoryModel> _categoriesList;

        public List<CategoryModel> CategoriesList { get => _categoriesList; }

        public ProductsListViewModel(IProductManagerService productManagerService,
            ICategoryManagerService categoryManagerService)
        {

            FilterProductsCommand = new FilterProductsCommand(this);

            ClearAllFiltersCommand = new ClearAllFiltersCommand(this);

            _productManagerService = productManagerService;

            _categoryManagerService = categoryManagerService;

            _products = new ObservableCollection<ProductViewModel>();

            InitialiseCategoriesList();

            UpdateProductsCollection();
        }

        public async void UpdateProductsCollection()
        {
            if (productsCache == null) productsCache = await _productManagerService.GetAllProducts();

            List<ProductModel> productsFiltered = new List<ProductModel>();

            productsFiltered.AddRange(productsCache);

            if (!String.IsNullOrEmpty(Query))
                productsFiltered = productsFiltered
                    .Where(product => product.Name.ToUpper().Contains(Query.ToUpper())).ToList();

            if (_category != null && _category.CategoryId != -1)
                productsFiltered = productsFiltered
                    .Where(product => product.CategoryId == _category.CategoryId).ToList();

            _products.Clear();
            foreach (var product in productsFiltered)
            {
                _products.Add(new ProductViewModel(product));
            }
        }

        public async void InitialiseCategoriesList()
        {
            _categoriesList = new List<CategoryModel>
            {
                new CategoryModel(-1, "All categories")

            };

            _categoriesList.AddRange(await _categoryManagerService.GetAllCategories());
        }
    }
}
