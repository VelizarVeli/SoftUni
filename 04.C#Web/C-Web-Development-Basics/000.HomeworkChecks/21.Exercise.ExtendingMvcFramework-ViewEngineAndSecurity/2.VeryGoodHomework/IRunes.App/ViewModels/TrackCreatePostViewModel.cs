using System.Collections.Generic;
using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class TrackCreatePostViewModel : ViewModel
    {
	public string AlbumId { get; set; }
	public string Artist { get; set; }
	public string Genre { get; set; }
	public string Link { get; set; }
	public string Price { get; set; }
	public string TrackId { get; set; }
	public string TrackTitle { get; set; }
	public IEnumerable<MusicGenreViewModel> MusicGenres { get; set; }
    }
}
