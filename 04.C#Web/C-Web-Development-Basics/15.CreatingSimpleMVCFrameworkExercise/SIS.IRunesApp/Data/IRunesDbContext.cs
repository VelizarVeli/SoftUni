namespace SIS.IRunesApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using IRunesApp.Data.Models;

    public class IRunesDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
    }
}
