namespace IRunesApp.Controllers
{
    using Common;
    using Models;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MVC.Framework.Attributes;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using ViewModels.Albums;

    public class AlbumsController : BaseController
    {
        [HttpGet("/albums/all")]
        public IHttpResponse All()
        {
            if (!this.IsAuthenticated())
            {
                return this.RedirectResult("users/login");
            }

            var allAlbums = new StringBuilder();
            var albums = this.Db.Albums;
            if (albums.Any())
            {
                foreach (var album in albums)
                {
                    allAlbums.AppendLine($@"<h6><a href = ""/albums/details?albumid={album.Id}"">{album.Name}</a></h6>");
                }

                this.ViewBag["albums"] = allAlbums.ToString();
            }
            else
            {
                this.ViewBag["albums"] = Messages.NoAlbums;
            }

            return this.View();
        }

        [HttpGet("/albums/create")]
        public IHttpResponse Create()
        {
            if (!this.IsAuthenticated())
            {
                return this.RedirectResult("users/login");
            }

            return this.View();
        }

        [HttpPost("/albums/create")]
        public IHttpResponse DoCreate(DoCreateAlbumInputModel model)
        {
            // Validate
            this.ValidateName(model.Name);

            // Create
            this.CreateAndSaveAlbum(model.Name, model.Cover);

            return this.RedirectResult("/albums/create");
        }

        [HttpGet("/albums/details")]
        public IHttpResponse Details()
        {
            var urlTokens = this.Request.Url.Split('?', StringSplitOptions.RemoveEmptyEntries);
            var albumId = urlTokens[1].Replace("albumid=", "");
            var album = this.Db.Albums.FirstOrDefault(a => a.Id == albumId);
            if (album != null)
            {
                this.ViewBag["cover"] = album.Cover;
                this.ViewBag["name"] = album.Name;
                this.ViewBag["price"] = album.Price.ToString(CultureInfo.InvariantCulture);
                this.ViewBag["albumId"] = $"?albumId={albumId}";

                var tracks = this.Db.Albums.FirstOrDefault(a => a.Id == albumId).Tracks.Select(ta => ta.Track);
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

        private void CreateAndSaveAlbum(string name, string cover)
        {
            var album = new Album()
            {
                Name = name,
                Cover = cover
            };

            try
            {
                this.Db.Albums.Add(album);
                this.Db.SaveChanges();
            }
            catch (Exception exception)
            {
                this.ServerError(exception.Message);
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                this.BadRequestError(Messages.InvalidAlbumName);
            }

            if (this.Db.Albums.Any(a => a.Name == name))
            {
                this.BadRequestError(Messages.AlbumExists);
            }
        }
    }
}