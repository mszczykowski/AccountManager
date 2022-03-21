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
using AccountManager.ViewModels.ProductsViewModels;
using AccountManager.Commands.MisicCommands;

namespace AccountManager.ViewModels.ManageProductsViewModels
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
