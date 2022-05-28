using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Services;
using ShopWPF.Commands;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Models;
using ShopWPF.Enums;
using ShopWPF.Stores;
using ShopWPF.ViewModels.ProductsViewModels;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class ManageProductsViewModel : ProductsListViewModel
    {
        public ICommand AddProductCommand { get; }

        public ICommand EditProductCommand { get; }

        public ICommand DeleteSelectedCommand { get; private set; }

        public ManageProductsViewModel(NavigationService<AdminMenuViewModel> adminMenuViewModelNavigationService, 
            NavigationService<AddProductViewModel> addProductViewModelNavigationService,
            NavigationService<EditProductViewModel> editProductViewModelNavigationService, 
            IProductsManagerService productManagerService, 
            ProductStore productStore) 
            : base(productManagerService)
        {
            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewModelNavigationService);

            AddProductCommand = new NavigateCommand<AddProductViewModel>(addProductViewModelNavigationService);

            EditProductCommand = new NavigateToEditProductCommand(productStore, editProductViewModelNavigationService);

            DeleteSelectedCommand = new DeleteSelectedCommand(this, _productManagerService);
        }
    }
}
