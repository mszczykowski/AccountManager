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

namespace AccountManager.ViewModels
{
    internal class ManageProductsViewModel : ViewModelBase
    {
        private readonly IProductManagerService _productManagerService;
        public ICommand BackCommand { get; }

        public ICommand SearchCommand { get; }

        private readonly ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;

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

        public ManageProductsViewModel(NavigationService userMenuViewNavigationService, IProductManagerService productManagerService)
        {
            BackCommand = new NavigateCommand(userMenuViewNavigationService);

            SearchCommand = new SearchProductCommand(this, productManagerService);

            _productManagerService = productManagerService;

            _products = new ObservableCollection<ProductViewModel>();
            UpdateProductsCollection(_productManagerService.GetAllProducts());
        }

        public void UpdateProductsCollection(IEnumerable<ProductModel> products)
        {
            _products.Clear();
            foreach(var product in products)
            {
                _products.Add(new ProductViewModel(product));
            }
        }
    }
}
