
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
    internal class EditCategoryCommand : CommandBase
    {
        private readonly NavigationService<ManageCategoriesViewModel> _manageCategoriesViewNavigationService;
        private readonly EditCategoryViewModel _categoryViewModel;
        private readonly ICategoryManagerService _categoryManagerService;
        private readonly int idToEdit;

        public EditCategoryCommand(NavigationService<ManageCategoriesViewModel> manageCategoriesViewNavigationService,
            EditCategoryViewModel categoryViewModel, ICategoryManagerService categoryManagerService, int id)
        {
            _manageCategoriesViewNavigationService = manageCategoriesViewNavigationService;
            _categoryViewModel = categoryViewModel;
            _categoryManagerService = categoryManagerService;
            idToEdit = id;
        }

        public async override void Execute(object? parameter)
        {
            _categoryViewModel.ValidateForm();

            if (_categoryViewModel.HasErrors) return;

            if (await _categoryManagerService.GetCategoryByName(_categoryViewModel.CategoryName) != null)
            {
                MessageBox.Show("Category already exists!");
                return;
            }

            await _categoryManagerService.EditCategory(idToEdit, new CategoryModel
            {
                Name = _categoryViewModel.CategoryName
            });

            MessageBox.Show("Category edited!");

            _manageCategoriesViewNavigationService.Navigate();
        }
    }
}
