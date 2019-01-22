using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class TrackViewModel : ViewModel
    {
	public string AlbumId { get; set; }
	public string TrackId { get; set; }
	public int TrackNumber { get; set; }
	public string TrackNumStyle { get; set; }
	public string TrackTitle { get; set; }
    }
}
