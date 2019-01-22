namespace WebServer.IRunesApplication.Data
{
    using Microsoft.EntityFrameworkCore;
    using IRunesApplication.Data.Models;

    public class IRunesDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=IRunesDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
