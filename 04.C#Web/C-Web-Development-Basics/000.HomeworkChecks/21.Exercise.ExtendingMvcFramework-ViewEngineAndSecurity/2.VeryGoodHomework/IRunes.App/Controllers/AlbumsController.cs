using System.Collections.Generic;
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
    public class AlbumsController : Controller, IAlbumsController
    {
	private readonly IAlbumService AlbumService;
	private readonly IEnumerationService Enumerator;

	public AlbumsController(IAlbumService albumService, IEnumerationService enumerationService)
	{
	    AlbumService = albumService;
	    Enumerator = enumerationService;
	}

	[HttpGet]
	[Authenticate]
	public IActionResult All(AlbumsViewModel model)
	{
	    model.Albums = AlbumService.GetAlbums()
		.Select(a => new AlbumViewModel()
		{
		    AlbumId = a.Id.ToString(),
		    AlbumName = a.ToString()
		});
	    model.HasAlbums = model.Albums.Any();
	    return View(model);
	}

	[HttpGet]
	[Authenticate]
	public IActionResult Create(AlbumCreateGetViewModel model)
	{
	    model.MusicGenres = Enumerator
		.GetTextValues(typeof(MusicGenre))
		.Select(displayName => new MusicGenreViewModel()
		{
		    DisplayName = displayName
		});
	    return View(model);
	}

	[HttpPost]
	public IActionResult Create(AlbumCreatePostViewModel model)
	{
	    string artist = model.Artist;
	    string title = model.AlbumTitle;
	    if (AlbumService.Exists(artist, title))
	    {
		model.Data[Constants.ErrorKey] = string.Format(
		    Constants.EntityExistsError, "Album", $"{artist} - {title}");
		model.MusicGenres = Enumerator
		.GetTextValues(typeof(MusicGenre))
		.Select(displayName => new MusicGenreViewModel()
		{
		    DisplayName = displayName
		});
		return View(model);
	    }
	    var genre = Enumerator.ToEnumOrDefault<MusicGenre>(model.Genre);
	    AlbumService.AddAlbum(artist, title, genre, model.CoverArt);
	    return RedirectTo(Constants.AlbumsViewRoute);
	}

	[HttpGet]
	[Authenticate]
	public IActionResult Details(AlbumDetailsViewModel model)
	{
	    if (model.AlbumId == null)
	    {
		return BadRequest(string.Format(
		    Constants.EntityPropertyMissingError, "Album", "ID"));
	    }
	    var album = AlbumService.GetAlbumById(model.AlbumId);
	    if (string.IsNullOrEmpty(album.CoverArt))
	    {
		model.AlbumCoverArt = Constants.DefaultAlbumCoverArt;
		model.AlbumCoverArtTooltip = Constants.ResourceNotAvailableMessage;
	    }
	    else
	    {
		model.AlbumCoverArt = album.CoverArt;
		model.AlbumCoverArtTooltip = string
		    .Format(Constants.AlbumCoverArtTooltip, album.ToString());
	    }
	    model.AlbumArtist = album.Artist;
	    model.AlbumTitle = album.Title;
	    string albumGenre = Enumerator.ToTextOrDefault(typeof(MusicGenre), album.Genre);
	    if (string.IsNullOrEmpty(albumGenre))
	    {
		model.AlbumGenre = default(MusicGenre).ToString();
	    }
	    else model.AlbumGenre = albumGenre;
	    var albumTracks = AlbumService.GetAlbumTracks(album).ToArray();
	    model.HasTracks = albumTracks.Any();
	    if (model.HasTracks)
	    {
		var trackList = new List<TrackViewModel>();
		for (int trackNumber = 1; trackNumber <= albumTracks.Length; trackNumber++)
		{
		    var track = albumTracks[trackNumber - 1];
		    var trackViewModel = new TrackViewModel()
		    {
			AlbumId = model.AlbumId,
			TrackId = track.Id.ToString(),
			TrackNumber = trackNumber,
			TrackTitle = track.Title
		    };
		    if (albumTracks.Length == 1) trackViewModel.TrackNumStyle = "none";
		    else trackViewModel.TrackNumStyle = "inline";
		    trackList.Add(trackViewModel);
		}
		model.AlbumTracks = trackList;
		decimal albumPrice = albumTracks.Sum(track => track.Price);
		if (albumTracks.Length > 1)
		{
		    albumPrice *= Constants.AlbumPriceDiscountMultiplier;
		}
		model.AlbumPrice = $"${albumPrice:F2}";
	    }
	    else model.AlbumPrice = "&mdash;";
	    return View(model);
	}
    }
}
