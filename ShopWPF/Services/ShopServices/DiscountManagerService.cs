using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Models;
using ShopWPF.Models.Discounts;
using ShopWPF.Services.Interfaces;
using System.Collections.Generic;
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
            await _context.Discounts.AddAsync(new DiscountDatabaseModel
            {
                Category = category,
            });
            await _context.SaveChangesAsync();
        }

        public async Task AddDiscount(ProductModel product)
        {
            await _context.Discounts.AddAsync(new DiscountDatabaseModel
            {
                Product = product,
            });
            await _context.SaveChangesAsync();
        }

        public async Task AddDiscount()
        {
            await _context.Discounts.AddAsync(new DiscountDatabaseModel());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiscount(int id)
        {
            var discountToRemove = await _context.Discounts
                .FirstOrDefaultAsync(discount => discount.Id == id);

            _context.Discounts.Remove(discountToRemove);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DiscountBaseModel>> GetDiscounts()
        {
            var discounts = await _context.Discounts.ToListAsync();

            List<DiscountBaseModel> discountBases = new List<DiscountBaseModel>();

            discounts.ForEach(d =>
            {
                if (d.Product != null) discountBases.Add(new ThirtyPercentOffProdcut(d.Id, d.Product));
                else if (d.Category != null) discountBases.Add(new FiftyPercentOffOnCategorySecondProduct(d.Id, d.Category));
                else discountBases.Add(new TenEveryHundredDiscount(d.Id));
            });

            return discountBases;
        }
    }
}
