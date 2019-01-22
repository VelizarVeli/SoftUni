using System.Collections.Generic;
using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class AlbumsViewModel : ViewModel
    {
	public bool HasAlbums { get; set; }
	public IEnumerable<AlbumViewModel> Albums { get; set; }
    }
}
