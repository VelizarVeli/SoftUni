using CakesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CakesWebApp.Data
{
    public class CakesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=Cakes;Integrated Security=True;").UseLazyLoadingProxies();
        }
    }
}
