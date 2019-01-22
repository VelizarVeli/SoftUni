using Microsoft.EntityFrameworkCore;
using Panda1.Models;

namespace Panda1.Data
{
    public class PandaDbContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=Panda1;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(a => a.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(fk => fk.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(r => r.Receipts)
                .WithOne(u => u.UserRecipient)
                .HasForeignKey(fk => fk.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Receipt>()
                .HasOne(a => a.Package)
                .WithOne(r => r.Receipt)
                .HasForeignKey<Receipt>(p => p.PackageId);
        }
    }
}
