using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.ViewModels;
using ShopWPF.ViewModels.ProductsViewModels;

namespace ShopWPF.Commands.ProductManagerCommands
{
    internal class ClearAllFiltersCommand : CommandBase
    {
        private readonly ProductsListViewModel _productsListViewModel;

        public ClearAllFiltersCommand(ProductsListViewModel productsListViewModel)
        {
            _productsListViewModel = productsListViewModel;
        }

        public override void Execute(object? parameter)
        {
            _productsListViewModel.Query = "";
            _productsListViewModel.Category = _productsListViewModel.CategoriesList[0];
            _productsListViewModel.UpdateProductsCollection();
        }
    }
}
