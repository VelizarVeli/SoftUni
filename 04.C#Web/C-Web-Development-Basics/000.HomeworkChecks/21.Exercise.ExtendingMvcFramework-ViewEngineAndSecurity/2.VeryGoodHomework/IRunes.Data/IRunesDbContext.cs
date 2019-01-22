using IRunes.Data.EntityConfiguration;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;

namespace IRunes.Data
{
    public class IRunesDbContext : DbContext
    {
	public IRunesDbContext() { }

	public IRunesDbContext(DbContextOptions<IRunesDbContext> options) : base(options) { }

	public virtual DbSet<Album> Albums { get; set; }
	public virtual DbSet<AlbumTrack> AlbumsTracks { get; set; }
	public virtual DbSet<Track> Tracks { get; set; }
	public virtual DbSet<User> Users { get; set; }
	public virtual DbSet<UserAlbum> UsersAlbums { get; set; }
	public virtual DbSet<UserTrack> UsersTracks { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
	    if (!optionsBuilder.IsConfigured)
	    {
		optionsBuilder
		.UseSqlServer(IRunesDbConfig.ConnectionString)
		.UseLazyLoadingProxies(true);
	    }
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	    modelBuilder.ApplyConfiguration(new AlbumConfiguration());
	    modelBuilder.ApplyConfiguration(new AlbumTrackConfiguration());
	    modelBuilder.ApplyConfiguration(new TrackConfiguration());
	    modelBuilder.ApplyConfiguration(new UserConfiguration());
	    modelBuilder.ApplyConfiguration(new UserAlbumConfiguration());
	    modelBuilder.ApplyConfiguration(new UserTrackConfiguration());
	}
    }
}
