using ShopWPF.Models;
using ShopWPF.ViewModels.Intefraces;

namespace ShopWPF.ViewModels.ManageCategoriesViewModels
{
    internal class CategoryViewModel : ViewModelBase, ViewModelWithId
    {
        private CategoryModel _category;

        public CategoryModel Category { get => _category; }

        public int Id => _category.CategoryId;
        public string Name => _category.Name;

        public CategoryViewModel(CategoryModel category)
        {
            _category = category;
        }
    }
}
