using Google.Models;
using Microsoft.EntityFrameworkCore;

namespace Google.Data
{
    public class GoogleContext : DbContext
    {
        public GoogleContext()
        {
        }

        public GoogleContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(x => x.Manager)
                    .WithMany(x => x.ManagerEmployees)
                    .HasForeignKey(x => x.ManagerId);
            });
        }
    }
}
