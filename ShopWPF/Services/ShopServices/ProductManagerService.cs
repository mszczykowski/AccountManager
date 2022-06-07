using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class ProductManagerService : IProductManagerService
    {
        private readonly ShopDBContext _context;

        public ProductManagerService(ShopDBContext context)
        {
            _context = context;
        }

        public async Task AddProduct(ProductModel product)
        {
            
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeQuantity(int productId, int newQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            product.Quantity = newQuantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.IsDeleted = true;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditProduct(int id, ProductModel product)
        {
            var toEdit = await _context.Products.FindAsync(id);
            toEdit.CopyData(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ProductModel>> GetAllProducts()
        {
            return await _context.Products.Where(product => product.IsDeleted == false).ToListAsync();
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            return await _context.Products.Where(_product => _product.ProductId == id 
            && _product.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<ProductModel> GetProductIncludingDeleted(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        }
    }
}
