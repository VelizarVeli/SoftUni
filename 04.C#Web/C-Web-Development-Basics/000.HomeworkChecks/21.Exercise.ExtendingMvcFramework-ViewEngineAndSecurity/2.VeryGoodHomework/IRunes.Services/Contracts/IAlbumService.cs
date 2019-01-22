using System;
using System.Collections.Generic;
using IRunes.Models;
using IRunes.Models.Enumerations;

namespace IRunes.Services.Contracts
{
    public interface IAlbumService
    {
	void AddAlbum(string artist, string title,
	    MusicGenre genre, string coverArt);
	Album GetAlbumById(Guid albumId);
	Album GetAlbumById(string albumId);
	Album GetAlbumByName(string artist, string title);
	bool Exists(string albumArtist, string albumTitle);
	IEnumerable<Album> GetAlbums();
	IEnumerable<Track> GetAlbumTracks(Album album);
    }
}
