using System.Linq;
using System.Threading.Tasks;
using IRunes.Data;
using IRunes.Models;
using IRunes.Models.Enumerations;
using IRunes.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace IRunes.Services
{
    public class DbInitializationService : IDbInitializationService
    {
	private bool isDbInitialized = false;

	public async Task<bool> InitializeDatabaseAsync(DbContext dbContext)
	{
	    var migrations = dbContext.Database.GetMigrations();
	    if (migrations.Count() > 0)
	    {
		dbContext.Database.Migrate();
		isDbInitialized = true;
	    }
	    else
	    {
		#region Uncomment if you want to wipe all data and start anew:
		/* context.Database.EnsureDeleted(); */
		#endregion
		await dbContext.Database.EnsureCreatedAsync();
		isDbInitialized = dbContext.Database
		    .GetService<IRelationalDatabaseCreator>().Exists();
	    }
	    PopulateDatabase(dbContext as IRunesDbContext);
	    return isDbInitialized;
	}

	private void PopulateDatabase(IRunesDbContext dbContext)
	{
	    if (!dbContext.Albums.Any() && !dbContext.Tracks.Any())
	    {
		var album1 = new Album() { Artist = "The Offspring", Title = "Americana", Genre = MusicGenre.PunkRock, CoverArt = "http://c0000636.cdn2.cloudfiles.rackspacecloud.com/americana_cover_t1.jpg" };
		var track1 = new Track() { Artist = album1.Artist, Title = "Pretty Fly (For a White Guy)", Genre = MusicGenre.PunkRock, Link = "https://www.youtube.com/embed/QtTR-_Klcq8", Price = 1.99M };
		var track2 = new Track() { Artist = album1.Artist, Title = "Why Don't You GET A Job?", Genre = MusicGenre.Rock, Link = "https://www.youtube.com/embed/LH-i8IvYIcg", Price = 1.99M };
		album1.Price += track1.Price + track2.Price;
		var album2 = new Album() { Artist = "Tchaikovsky", Title = "Greatest Hits", Genre = MusicGenre.Classical };
		var track3 = new Track() { Artist = album2.Artist, Title = "Nocturne", Genre = MusicGenre.Classical, Link = "http://www.hochmuth.com/mp3/Tchaikovsky_Nocturne__orch.mp3", Price = 0.99M };
		album2.Price += track3.Price;
		dbContext.Albums.Add(album1);
		dbContext.Albums.Add(album2);
		dbContext.Tracks.Add(track1);
		dbContext.Tracks.Add(track2);
		dbContext.Tracks.Add(track3);
		dbContext.SaveChanges();
		album1.AlbumTracks.Add(new AlbumTrack() { AlbumId = album1.Id, TrackId = track1.Id });
		album1.AlbumTracks.Add(new AlbumTrack() { AlbumId = album1.Id, TrackId = track2.Id });
		album2.AlbumTracks.Add(new AlbumTrack() { AlbumId = album2.Id, TrackId = track3.Id });
		dbContext.SaveChanges();
	    }
	}
    }
}
