using ShopWPF.Commands.CategoryManagerCommands;
using ShopWPF.Models;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageCategoriesViewModels
{
    internal class EditCategoryViewModel : CategoryFormViewModel
    {
        public ICommand EditCategoryCommand { get; }

        private CategoryModel categoryToEdit;

        public EditCategoryViewModel(NavigationService<ManageCategoriesViewModel> manageCategoriesViewNavigationService, ICategoryManagerService categoryManagerService, 
            IdStore idStore)
            : base(manageCategoriesViewNavigationService)
        {
            LoadCategory(idStore.Id, categoryManagerService);

            EditCategoryCommand = new EditCategoryCommand(manageCategoriesViewNavigationService, this, categoryManagerService, int id);
        }

        private async void LoadCategory(int id, ICategoryManagerService categoryManagerService)
        {
            categoryToEdit = await categoryManagerService.GetCategory(id);
        }
    }
}
