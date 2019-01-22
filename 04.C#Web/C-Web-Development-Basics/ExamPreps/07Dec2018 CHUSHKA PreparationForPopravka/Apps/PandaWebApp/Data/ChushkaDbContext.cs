using ChushkaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChushkaWebApp.Data
{
    public class ChushkaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ChushkaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=CHUSHKA;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(u => u.Client)
                .WithMany(p => p.Orders)
                .HasForeignKey(fk => fk.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Product)
                .WithMany(c => c.Orders)
                .HasForeignKey(fk => fk.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasKey(ck => new { ck.ProductId, ck.ClientId });
        }
    }
}
