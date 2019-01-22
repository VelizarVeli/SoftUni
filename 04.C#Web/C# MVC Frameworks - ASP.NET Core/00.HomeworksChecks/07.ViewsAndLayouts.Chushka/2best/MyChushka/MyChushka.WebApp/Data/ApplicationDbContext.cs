using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyChushka.WebApp.Models;

namespace MyChushka.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder
            //    .Entity<AppUser>()
            //    .HasMany(u => u.Orders)
            //    .WithOne(o => o.Client)
            //    .HasForeignKey(o => o.ClientId);

            //builder
            //    .Entity<Product>()
            //    .HasMany(p => p.Orders)
            //    .WithOne(o => o.Product)
            //    .HasForeignKey(o => o.ProductId);

            base.OnModelCreating(builder);
        }
    }
}
