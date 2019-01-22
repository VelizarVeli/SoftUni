using System;
using System.Collections.Generic;
using IRunes.Models.Enumerations;

namespace IRunes.Models
{
    public class Album : BaseModel<Guid>
    {
	public Album()
	{
	    AlbumTracks = new HashSet<AlbumTrack>();
	    AlbumUsers = new HashSet<UserAlbum>();
	}

	public string Artist { get; set; }
	public string Title { get; set; }
	public MusicGenre Genre { get; set; }
	public string CoverArt { get; set; }
	public decimal Price { get; set; }

	public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
	public virtual ICollection<UserAlbum> AlbumUsers { get; set; }

	public override string ToString()
	{
	    return $"{Artist} - {Title}";
	}
    }
}
