using IRunesWebApp.Models;

using Microsoft.EntityFrameworkCore;

namespace IRunesWebApp.Data
{
    public class IRunesContext : DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-8ECROG0\SQLEXPRESS; Database=IRunesApp; Integrated Security=true";

        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<TrackAlbum> TracksAlbums { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackAlbum>()
                .HasKey(ta => new { ta.AlbumId, ta.TrackId });
        }
    }
}
