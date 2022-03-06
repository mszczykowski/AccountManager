using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels;

namespace AccountManager.Commands.ProductManagerCommands
{
    internal class ClearAllFiltersCommand : CommandBase
    {
        private readonly ManageProductsViewModel _manageProductsViewModel;

        public ClearAllFiltersCommand(ManageProductsViewModel manageProductsViewModel)
        {
            _manageProductsViewModel = manageProductsViewModel;
        }

        public override void Execute(object? parameter)
        {
            _manageProductsViewModel.Search = "";
            _manageProductsViewModel.Category = _manageProductsViewModel.CategoriesList[0];
            _manageProductsViewModel.UpdateProductsCollection();
        }
    }
}
