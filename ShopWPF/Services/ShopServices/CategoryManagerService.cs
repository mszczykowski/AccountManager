using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class CategoryManagerService : ICategoryManagerService
    {
        private readonly ShopDBContext _context;

        public CategoryManagerService(ShopDBContext context)
        {
            _context = context;
        }

        public async Task AddCategory(CategoryModel category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(category => category.CategoryId == categoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task EditCategory(int id, CategoryModel category)
        {
            var categroyToEdit = await _context.Categories.FindAsync(id);

            categroyToEdit.Name = category.Name;

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryModel>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryModel> GetCategory(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<CategoryModel> GetCategoryByName(string name)
        {
            return await _context.Categories.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}
