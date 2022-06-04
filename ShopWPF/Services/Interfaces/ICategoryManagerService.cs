using ShopWPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWPF.Services.Interfaces
{
    internal interface ICategoryManagerService
    {
        Task<ICollection<CategoryModel>> GetAllCategories();

        Task AddCategory(CategoryModel category);

        Task EditCategory(int id, CategoryModel category);

        Task<CategoryModel> GetCategory(int categoryId);

        Task DeleteCategory(int categoryId);

        Task<CategoryModel> GetCategoryByName(string name);
    }
}
