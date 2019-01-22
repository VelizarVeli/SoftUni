using SIS.Framework.Models;

namespace IRunes.App.ViewModels
{
    public class TrackDetailsViewModel : ViewModel
    {
	public string AlbumId { get; set; }
	public string Artist { get; set; }
	public string Genre { get; set; }
	public string TrackId { get; set; }
	public string Link { get; set; }
	public string Price { get; set; }
	public string TrackTitle { get; set; }
    }
}
