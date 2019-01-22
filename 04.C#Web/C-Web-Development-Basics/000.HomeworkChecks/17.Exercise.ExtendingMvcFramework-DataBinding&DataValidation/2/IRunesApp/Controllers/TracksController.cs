namespace IRunesApp.Controllers
{
    using Common;
    using Models;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MVC.Framework.Attributes;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using ViewModels.Tracks;

    public class TracksController : BaseController
    {
        [HttpGet("/tracks/create")]
        public IHttpResponse Create()
        {
            if (!this.IsAuthenticated())
            {
                return this.RedirectResult("users/login");
            }

            return this.View();
        }

        [HttpPost("/tracks/create")]
        public IHttpResponse DoCreate(DoCreateTrackInputModel model)
        {
            var urlTokens = this.Request.Headers.GetHeader("Referer").Value.Split('?', StringSplitOptions.RemoveEmptyEntries);
            var albumId = urlTokens[1].Replace("albumId=", "");

            // Validate
            this.ValidateName(model.Name);
            //this.ValidateLink(link);

            // Create
            this.CreateAndSaveTrack(model.Name, model.Link, model.Price, albumId);

            this.ViewBag["albumId"] = $"?albumid={albumId}";

            return this.RedirectResult("/tracks/create");
        }

        [HttpGet("/tracks/details")]
        public IHttpResponse Details()
        {
            var urlTokens = this.Request.Url.Split('?', StringSplitOptions.RemoveEmptyEntries);
            var ids = urlTokens[1].Split('&', StringSplitOptions.RemoveEmptyEntries);
            var albumId = ids[0].Replace("albumid=", "");
            var trackId = ids[1].Replace("trackid=", "");
            var track = this.Db.Tracks.FirstOrDefault(t => t.Id == trackId);
            if (track != null)
            {
                this.ViewBag["link"] = track.Link;
                this.ViewBag["name"] = track.Name;
                this.ViewBag["price"] = track.Price.ToString(CultureInfo.InvariantCulture);
                this.ViewBag["albumId"] = $"?albumId={albumId}";
            }
            else
            {
                this.ViewBag["link"] = Messages.NoTrackInfo;
                this.ViewBag["name"] = "";
                this.ViewBag["price"] = "";
                this.ViewBag["albumId"] = "";
            }

            return this.View();
        }

        private void CreateAndSaveTrack(string name, string link, decimal price, string albumId)
        {
            var track = new Track()
            {
                Name = name,
                Link = link,
                Price = price
            };

            var trackAlbum = new TrackAlbum();
            trackAlbum.AlbumId = albumId;
            track.Albums.Add(trackAlbum);

            try
            {
                this.Db.Tracks.Add(track);
                this.Db.SaveChanges();
            }
            catch (Exception exception)
            {
                this.ServerError(exception.Message);
            }
        }

        private void ValidateLink(string link)
        {
            var url = WebUtility.UrlDecode(link);
            var validUri = new Uri(url);
            if (string.IsNullOrWhiteSpace(validUri.Scheme) ||
                string.IsNullOrWhiteSpace(validUri.Host) ||
                string.IsNullOrWhiteSpace(validUri.LocalPath) ||
                !validUri.IsDefaultPort)
            {
                this.BadRequestError(Messages.InvalidUrl);
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                this.BadRequestError(Messages.InvalidTrackName);
            }

            if (this.Db.Tracks.Any(t => t.Name == name))
            {
                this.BadRequestError(Messages.TrackExists);
            }
        }
    }
}