using System;
using System.Collections.Generic;
using IRunes.Models.Enumerations;

namespace IRunes.Models
{
    public class Track : BaseModel<Guid>
    {
	public Track()
	{
	    TrackAlbums = new HashSet<AlbumTrack>();
	    TrackUsers = new HashSet<UserTrack>();
	}

	public string Artist { get; set; }
	public string Title { get; set; }
	public MusicGenre Genre { get; set; }
	public string Link { get; set; }
	public decimal Price { get; set; }

	public virtual ICollection<AlbumTrack> TrackAlbums { get; set; }
	public virtual ICollection<UserTrack> TrackUsers { get; set; }
    }
}
