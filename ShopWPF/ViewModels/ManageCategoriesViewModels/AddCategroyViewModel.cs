using ShopWPF.Commands.CategoryManagerCommands;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageCategoriesViewModels
{
    internal class AddCategroyViewModel : CategoryFormViewModel
    {
        public ICommand AddCategoryCommand { get; }

        public AddCategroyViewModel(NavigationService<ManageCategoriesViewModel> manageCategoriesViewNavigationService, ICategoryManagerService categoryManagerService)
            : base (manageCategoriesViewNavigationService)
        {
            AddCategoryCommand = new AddCategoryCommand(manageCategoriesViewNavigationService, this, categoryManagerService);

        }
    }
}
