using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Services;
using ShopWPF.ViewModels;
using ShopWPF.ViewModels.ProductsViewModels;

namespace ShopWPF.Commands.ProductManagerCommands
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
