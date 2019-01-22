using System.Linq;
using IRunes.App.Common;
using IRunes.App.Controllers.Contracts;
using IRunes.App.ViewModels;
using IRunes.Models.Enumerations;
using IRunes.Services.Contracts;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.Framework.Controllers;
using SIS.Services.Contracts;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller, ITracksController
    {
	private readonly ITrackService TrackService;
	private readonly IAlbumService AlbumService;
	private readonly IAlbumTrackService AlbumTrackService;
	private readonly IEnumerationService Enumerator;

	public TracksController(ITrackService trackService, IAlbumTrackService albumTrackService,
	    IAlbumService albumService, IEnumerationService enumerationService)
	{
	    TrackService = trackService;
	    AlbumService = albumService;
	    AlbumTrackService = albumTrackService;
	    Enumerator = enumerationService;
	}

	[HttpGet]
	[Authenticate]
	public IActionResult Create(TrackCreateGetViewModel model)
	{
	    if (model.AlbumId == null)
	    {
		return BadRequest(string.Format(
		    Constants.EntityPropertyMissingError, "Album", "ID"));
	    }
	    var album = AlbumService.GetAlbumById(model.AlbumId);
	    model.Artist = album.Artist;
	    model.MusicGenres = Enumerator
		.GetTextValues(typeof(MusicGenre))
		.Select(displayName => new MusicGenreViewModel()
		{
		    DisplayName = displayName
		});
	    return View(model);
	}

	[HttpPost]
	public IActionResult Create(TrackCreatePostViewModel model)
	{
	    if (model.AlbumId == null)
	    {
		return BadRequest(string.Format(
		    Constants.EntityPropertyMissingError, "Album", "ID"));
	    }
	    var album = AlbumService.GetAlbumById(model.AlbumId);
	    string artist = model.Artist;
	    string title = model.TrackTitle;
	    if (TrackService.Exists(artist, title))
	    {
		model.Data[Constants.ErrorKey] = string.Format(
		    Constants.EntityExistsError, "Track", $"{artist} - {title}");
		model.MusicGenres = Enumerator
		.GetTextValues(typeof(MusicGenre))
		.Select(displayName => new MusicGenreViewModel()
		{
		    DisplayName = displayName
		});
		return View(model);
	    }
	    var genre = Enumerator.ToEnumOrDefault<MusicGenre>(model.Genre);
	    decimal price = decimal.Parse(model.Price);
	    TrackService.AddTrack(artist, title, genre, model.Link, price);
	    var track = TrackService.GetTrackByName(artist, title);
	    AlbumTrackService.AddAlbumTrack(album.Id, track.Id);
	    model.TrackId = track.Id.ToString();
	    return RedirectTo(string.Format(Constants.TrackDetailsViewRoute, model.AlbumId, model.TrackId));
	}

	[HttpGet]
	[Authenticate]
	public IActionResult Details(TrackDetailsViewModel model)
	{
	    if (model.AlbumId == null)
	    {
		return BadRequest(string.Format(
		    Constants.EntityPropertyMissingError, "Track", "ID"));
	    }
	    var track = TrackService.GetTrackById(model.TrackId);
	    model.Artist = track.Artist;
	    model.TrackTitle = track.Title;
	    string trackGenre = Enumerator.ToTextOrDefault(typeof(MusicGenre), track.Genre);
	    if (string.IsNullOrEmpty(trackGenre))
	    {
		model.Genre = default(MusicGenre).ToString();
	    }
	    else model.Genre = trackGenre;
	    model.Price = $"${track.Price:F2}";
	    model.Link = track.Link.Replace("watch?v=", "embed/");
	    return View(model);
	}
    }
}
