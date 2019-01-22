using ChushkaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChushkaWebApp.Data
{
    public class ChushkaDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=Chushka;Integrated Security=True;");
        }
    }
}
