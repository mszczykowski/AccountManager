using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageCategoriesViewModels
{
    internal class ManageCategoriesViewModel : ViewModelBase
    {
        private readonly ICategoryManagerService _categoryManagerService;
        public ICommand AddCategoryCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand NavigateToEditCommand { get; }


        public ObservableCollection<CategoryViewModel> Categories { get; }

        public ManageCategoriesViewModel(NavigationService<AddCategroyViewModel> addCategoryViewNavigationService,
            NavigationService<AdminMenuViewModel> adminMenuViewNavigationService,
            NavigationService<EditCategoryViewModel> editCategoryViewNavigationService,
            ICategoryManagerService categoryManagerService, IdStore idStore)
        {
            AddCategoryCommand = new NavigateCommand<AddCategroyViewModel>(addCategoryViewNavigationService);

            BackCommand = new NavigateCommand<AdminMenuViewModel>(adminMenuViewNavigationService);

            NavigateToEditCommand = new NaviagteAndStoreIdCommand<EditCategoryViewModel>(editCategoryViewNavigationService, idStore);

            _categoryManagerService = categoryManagerService;


            Categories = new ObservableCollection<CategoryViewModel>();
            

            UpdateCategories();
        }

        private async void UpdateCategories()
        {
            var categories = await _categoryManagerService.GetAllCategories();

            foreach (var c in categories)
            {
                Categories.Add(new CategoryViewModel(c));
            }
        }
    }
}
