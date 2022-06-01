using Microsoft.EntityFrameworkCore;
using ShopWPF.Models;
using ShopWPF.Models.Discounts;

namespace ShopWPF.Data
{
    internal class ShopDBContext : DbContext
    {
        public DbSet<DiscountDatabaseModel> Discounts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderProductModel> OrderProducts { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ShoppingCartEntryModel> ShoppingCartEntries { get; set; }
        public DbSet<OrderStatusModel> OrderStatuses { get; set; }
        public ShopDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingCartEntryModel>().HasKey(entry => new { entry.ProductId, entry.CustomerId });

            
        }
    }
}
