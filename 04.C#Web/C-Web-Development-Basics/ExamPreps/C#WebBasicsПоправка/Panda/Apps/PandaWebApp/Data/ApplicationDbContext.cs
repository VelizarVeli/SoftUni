using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models;

namespace PandaWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=PandaDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(r => r.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(fk => fk.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Packages)
                .WithOne(r => r.Recipient)
                .HasForeignKey(fk => fk.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
