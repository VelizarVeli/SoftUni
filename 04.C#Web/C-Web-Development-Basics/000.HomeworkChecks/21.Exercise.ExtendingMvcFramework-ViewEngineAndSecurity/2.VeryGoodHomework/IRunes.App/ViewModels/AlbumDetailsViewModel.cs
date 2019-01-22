using System.Collections.Generic;
using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class AlbumDetailsViewModel : ViewModel
    {
	public string AlbumArtist { get; set; }
	public string AlbumCoverArt { get; set; }
	public string AlbumCoverArtTooltip { get; set; }
	public string AlbumGenre { get; set; }
	public string AlbumId { get; set; }
	public string AlbumPrice { get; set; }
	public string AlbumTitle { get; set; }
	public IEnumerable<TrackViewModel> AlbumTracks { get; set; }
	public bool HasTracks { get; set; }
    }
}
