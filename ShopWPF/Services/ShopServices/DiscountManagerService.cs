using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Discounts;
using ShopWPF.Models;
using ShopWPF.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class DiscountManagerService : IDiscountManagerService
    {
        private readonly ShopDBContext _context;

        public DiscountManagerService(ShopDBContext context)
        {
            _context = context;
        }

        public async Task AddDiscount(CategoryModel category)
        {
            await _context.DiscountBases.AddAsync(new FiftyPercentOffOnCategorySecondProduct(category));
            await _context.SaveChangesAsync();
        }

        public async Task AddDiscount(ProductModel product)
        {
            await _context.DiscountBases.AddAsync(new ThirtyPercentOffProdcut(product));
            await _context.SaveChangesAsync();
        }

        public async Task AddDiscount()
        {
            await _context.DiscountBases.AddAsync(new TenEveryHundredDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiscount(int id)
        {
            var discountToRemove = await _context.DiscountBases
                .FirstOrDefaultAsync(discount => discount.DiscountId == id);

            _context.DiscountBases.Remove(discountToRemove);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DiscountBaseModel>> GetDiscounts()
        {
            return await _context.DiscountBases.ToListAsync();
        }
    }
}
