using System;

namespace IRunes.Models
{
    public class AlbumTrack
    {
	public Guid AlbumId { get; set; }
	public virtual Album Album { get; set; }

	public Guid TrackId { get; set; }
	public virtual Track Track { get; set; }
    }
}
