using ShopWPF.Models;
using ShopWPF.Services.Common;
using ShopWPF.Services.Interfaces;
using ShopWPF.ViewModels.ManageCategoriesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopWPF.Commands.CategoryManagerCommands
{
    internal class AddCategoryCommand : CommandBase
    {
        private readonly NavigationService<ManageCategoriesViewModel> _manageCategoriesViewNavigationService;
        private readonly AddCategroyViewModel _categoryViewModel;
        private readonly ICategoryManagerService _categoryManagerService;


        public AddCategoryCommand(NavigationService<ManageCategoriesViewModel> manageCategoriesViewNavigationService,
            AddCategroyViewModel categoryViewModel, ICategoryManagerService categoryManagerService)
        {
            _manageCategoriesViewNavigationService = manageCategoriesViewNavigationService;
            _categoryViewModel = categoryViewModel;
            _categoryManagerService = categoryManagerService;
        }

        public override void Execute(object? parameter)
        {
            _categoryViewModel.ValidateForm();

            if (_categoryViewModel.HasErrors) return;

            _categoryManagerService.AddCategory(new CategoryModel
            {
                Name = _categoryViewModel.CategoryName
            });

            MessageBox.Show("Category created!");

            _manageCategoriesViewNavigationService.Navigate();
        }
    }
}
