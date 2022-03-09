using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Services;
using AccountManager.ViewModels;
using AccountManager.ViewModels.ProductsViewModels;

namespace AccountManager.Commands.ProductManagerCommands
{
    internal class FilterProductsCommand : CommandBase
    {
        private readonly ProductsListViewModel _productsListViewModel;

        public FilterProductsCommand(ProductsListViewModel productsListViewModel)
        {
            _productsListViewModel = productsListViewModel;
        }
        
        public override void Execute(object? parameter)
        {
            _productsListViewModel.UpdateProductsCollection();
        }
    }
}
