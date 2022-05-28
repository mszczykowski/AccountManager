using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class ShoppingCartService : IShoppingCartService
    {
        private readonly ShopDBContext _context;

        public ShoppingCartService(ShopDBContext context)
        {
            _context = context;
        }
        public async Task AddProductToCart(int userId, ProductModel product)
        {
            var user = await _context.Users.Include(user => user.ShoppingCart)
                .FirstOrDefaultAsync(user => user.UserId == userId);
            user.ShoppingCart.Add(new ShoppingCartEntryModel(product));
            await _context.SaveChangesAsync();
        }

        public async Task ClearCart(int userId)
        {
            var user = await _context.Users.Include(user => user.ShoppingCart)
                .FirstOrDefaultAsync(user => user.UserId == userId);
            user.ShoppingCart.Clear();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductFromCart(int userId, ProductModel product)
        {
            var toDelete = await _context.ShoppingCartEntries
                .FirstOrDefaultAsync(entry => entry.CustomerId == userId && entry.ProductId == product.ProductId);

            _context.ShoppingCartEntries.Remove(toDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ShoppingCartEntryModel>> LoadCart(int userId)
        {
            return await _context.ShoppingCartEntries.Where(entry => entry.CustomerId == userId).ToListAsync();
        }

        public async Task UpdateProductQuantity(int userId, int productId, int newQuantity)
        {
            var entryToUpdate = await _context.ShoppingCartEntries
                .FirstOrDefaultAsync(entry => entry.ProductId == productId && entry.CustomerId == userId);
            entryToUpdate.Quantity = newQuantity;
            await _context.SaveChangesAsync();
        }
    }
}
