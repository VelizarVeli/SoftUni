using System;
using IRunes.Models;
using IRunes.Models.Enumerations;

namespace IRunes.Services.Contracts
{
    public interface ITrackService
    {
	void AddTrack(string artist, string title,
	    MusicGenre genre, string link, decimal price);
	bool Exists(string trackArtist, string trackTitle);
	Track GetTrackByName(string artist, string title);
	Track GetTrackById(Guid trackId);
	Track GetTrackById(string trackId);
    }
}
