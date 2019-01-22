using System;
using System.Collections.Generic;

namespace IRunes.Models
{
    public class User : BaseModel<Guid>
    {
	public User()
	{
	    UserTracks = new HashSet<UserTrack>();
	    UserAlbums = new HashSet<UserAlbum>();
	}

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Email { get; set; }

	public virtual ICollection<UserTrack> UserTracks { get; set; }
	public virtual ICollection<UserAlbum> UserAlbums { get; set; }
    }
}
