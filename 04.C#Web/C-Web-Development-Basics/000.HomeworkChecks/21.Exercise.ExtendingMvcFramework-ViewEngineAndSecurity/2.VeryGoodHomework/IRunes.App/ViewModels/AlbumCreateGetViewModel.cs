using System.Collections.Generic;
using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class AlbumCreateGetViewModel : ViewModel
    {
	public IEnumerable<MusicGenreViewModel> MusicGenres { get; set; }
    }
}
