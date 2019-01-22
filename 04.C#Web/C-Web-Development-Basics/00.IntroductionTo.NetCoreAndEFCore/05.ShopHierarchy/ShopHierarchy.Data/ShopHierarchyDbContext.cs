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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
