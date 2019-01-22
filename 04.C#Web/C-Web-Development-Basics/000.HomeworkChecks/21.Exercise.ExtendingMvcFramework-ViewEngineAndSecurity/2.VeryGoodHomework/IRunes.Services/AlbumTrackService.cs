using System;
using IRunes.Data;
using IRunes.Models;
using IRunes.Services.Contracts;

namespace IRunes.Services
{
    public class AlbumTrackService : IAlbumTrackService
    {
	private readonly IRunesDbContext Context;

	public AlbumTrackService(IRunesDbContext dbContext)
	{
	    Context = dbContext;
	}

	public void AddAlbumTrack(Guid albumId, Guid trackId)
	{
	    var album = Context.Albums.Find(albumId);
	    var albumTrack = new AlbumTrack()
	    {
		AlbumId = albumId,
		TrackId = trackId
	    };
	    album.AlbumTracks.Add(albumTrack);
	    var track = Context.Tracks.Find(trackId);
	    album.Price += track.Price;
	    Context.SaveChanges();
	}
    }
}
