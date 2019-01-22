using System;

namespace IRunes.Data
{
    using IRunes.Models.Models;
    using Microsoft.EntityFrameworkCore;
    public class IRunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KING\\SQLEXPRESS; Database=IRunes3; Integrated Security=true");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
