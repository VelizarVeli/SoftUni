using Microsoft.EntityFrameworkCore;
using ShopHierarchy.Models;

namespace ShopHierarchy.Data
{
    public class ShopHierarchyDbContext : DbContext
    {
        public ShopHierarchyDbContext()
        {
        }

        public ShopHierarchyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemOrder> ItemsOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemOrder>()
                .HasKey(io => new {io.ItemId, io.OrderId});
        }
    }
}
