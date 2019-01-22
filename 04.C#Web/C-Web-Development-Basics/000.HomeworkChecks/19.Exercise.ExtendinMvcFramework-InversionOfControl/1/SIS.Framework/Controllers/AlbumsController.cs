namespace SIS.Framework.Controllers
{
    using ActionResults.Contracts;
    using Common;
    using Services.Contracts;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using ViewModels;

    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly ITrackService trackService;

        public AlbumsController(IAlbumService albumService, ITrackService trackService)
        {
            this.albumService = albumService;
            this.trackService = trackService;
        }

        public IActionResult All()
        {
            if (!this.IsAuthenticated())
            {
                return this.RedirectToAction("users/login");
            }

            var allAlbums = new StringBuilder();
            var albums = this.albumService.AllAlbums();
            if (albums.Any())
            {
                foreach (var album in albums)
                {
                    allAlbums.AppendLine($@"<h6><a href = ""/albums/details?id={album.Id}"">{album.Name}</a></h6>");
                }

                this.ViewBag["albums"] = allAlbums.ToString();
            }
            else
            {
                this.ViewBag["albums"] = Messages.NoAlbums;
            }

            return this.View();
        }

        public IActionResult Create()
        {
            if (!this.IsAuthenticated())
            {
                return this.RedirectToAction("users/login");
            }

            return this.View();
        }

        public IActionResult Create(CreateAlbumViewModel model)
        {
            this.albumService.CreateAndSaveAlbum(model.Name, model.Cover);

            return this.RedirectToAction("/albums/create");
        }

        public IActionResult Details()
        {
            var urlTokens = this.Request.Url.Split('?', StringSplitOptions.RemoveEmptyEntries);
            var albumId = urlTokens[1].Replace("id=", "");
            var album = this.albumService.ById(albumId);
            if (album != null)
            {
                this.ViewBag["cover"] = album.Cover;
                this.ViewBag["name"] = album.Name;
                this.ViewBag["price"] = album.Price.ToString(CultureInfo.InvariantCulture);
                this.ViewBag["albumId"] = $"?albumId={albumId}";

                var tracks = this.trackService.AllTracks(albumId);
                var trackList = new StringBuilder();
                var counter = 1;
                foreach (var track in tracks)
                {
                    trackList.AppendLine($@"<h6><a href = ""/tracks/details?albumId={album.Id}&trackId={track.Id}"">&nbsp;&nbsp;&nbsp;&#8226;&nbsp;{counter++}. {track.Name}</a></h6>");
                }

                this.ViewBag["tracks"] = trackList.ToString();
            }
            else
            {
                this.ViewBag["image"] = Messages.NoTracks;
                this.ViewBag["name"] = "";
                this.ViewBag["price"] = "";
                this.ViewBag["tracks"] = "";
                this.ViewBag["albumId"] = "";
            }

            return this.View();
        }
    }
}