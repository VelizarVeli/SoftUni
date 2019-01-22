using System.Collections.Generic;
using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class TrackCreateGetViewModel : ViewModel
    {
	public string AlbumId { get; set; }
	public string Artist { get; set; }
	public IEnumerable<MusicGenreViewModel> MusicGenres { get; set; }
    }
}
