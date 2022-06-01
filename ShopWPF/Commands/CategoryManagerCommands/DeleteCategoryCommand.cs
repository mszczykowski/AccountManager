using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.ViewModels.ManageCategoriesViewModels;
using System.Windows;

namespace ShopWPF.Commands.CategoryManagerCommands
{
    internal class DeleteCategoryCommand : CommandBase
    {
        private readonly ICategoryManagerService _categoryManagerService;
        private readonly int categoryToDeleteId;
        private readonly NavigationService<ManageCategoriesViewModel> _manageCategoriesViewNavigationService;

        public DeleteCategoryCommand(ICategoryManagerService categoryManagerService, int id, NavigationService<ManageCategoriesViewModel> manageCategoriesViewNavigationService)
        {
            _categoryManagerService = categoryManagerService;
            categoryToDeleteId = id;
            _manageCategoriesViewNavigationService = manageCategoriesViewNavigationService;
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Delete category?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.No) return;

            _categoryManagerService.DeleteCategory(categoryToDeleteId);

            _manageCategoriesViewNavigationService.Navigate();
        }
    }
}
