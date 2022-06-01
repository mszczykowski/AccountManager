using System;
using System.Windows.Input;
using ShopWPF.Commands.ProductManagerCommands;
using ShopWPF.Commands.MisicCommands;
using System.ComponentModel;
using System.Collections;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class AddProductViewModel : ProductFormViewModel
    {
        public ICommand AddProductCommand { get; }

        public AddProductViewModel(NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService, 
            IProductManagerService productsManagerService) : base(manageProductsViewModelNavigationService)
        {
            AddProductCommand = new AddProductCommand(this, manageProductsViewModelNavigationService, productsManagerService);
        }
    }
}
