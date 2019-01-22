using IRunes.Extensions;
using IRunes.Models;
using IRunes.ViewModels.Track;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using System.Linq;
using System.Text;

namespace IRunes.Controllers
{
    public class TrackController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            if (this.User == null)
            {
                return this.View();
            }

            string albumId = this.Request.QueryData["albumId"].ToString();
            this.Model["albumId"] = albumId;

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (this.User == null)
            {
                return this.View();
            }

            string albumId = this.Request.QueryData["albumId"].ToString();

            string name = model.Name;
            string link = model.Link;
            decimal price = model.Price;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(link) || price == 0)
            {
                return this.View();
            }

            var album = this.context.Albums.Include(x => x.Tracks).FirstOrDefault(x => x.Id == albumId);

            album.Tracks.Add(new Track { Name = name, Link = link, Price = price });
            this.context.SaveChanges();

            string albumCover = album.Cover.UrlDecode();

            var tracksPrice = album.Tracks.Sum(x => x.Price);
            var tracksPriceAfterDiscount = tracksPrice - (tracksPrice * 13 / 100);

            var albumData = new StringBuilder();
            albumData.Append($"<br/><img src=\"{albumCover}\" width=\"250\" height=\"250\"><br/>");
            albumData.Append($"<b>Name: {album.Name}</b><br/>");
            albumData.Append($"<b>Price: ${tracksPriceAfterDiscount}</b><br/>");

            var tracks = album.Tracks.ToArray();

            var sbTracks = new StringBuilder();

            this.Model["tracks"] = "";

            if (tracks.Length > 0)
            {
                foreach (var track in tracks)
                {
                    sbTracks.Append($"<a href=\"/track/details?id={track.Id}&albumId={albumId}\">{track.Name}</a></li><br/>");
                }

                this.Model["tracks"] = sbTracks.ToString();
            }

            this.Model["albumId"] = album.Id;
            this.Model["album"] = albumData.ToString();

            return this.View("/Album/Details");
        }

        [HttpGet]
        public IActionResult Details()
        {
            if (this.User == null)
            {
                return this.View();
            }

            var trackId = this.Request.QueryData["id"].ToString();
            var albumId = this.Request.QueryData["albumId"].ToString();

            var track = this.context.Tracks.FirstOrDefault(t => t.Id == trackId);

            string trackLink = track.Link.UrlDecode();

            var trackInfo = new StringBuilder();
            trackInfo.Append($"<b>Track Name: {track.Name}</b><br/>");
            trackInfo.Append($"<b>Track Price: ${track.Price}</b><br/>");

            string trackVideo = $"<iframe class=\"embed-responsive-item\" src=\"{trackLink}\"></iframe><br/>";

            this.Model["trackVideo"] = trackVideo;
            this.Model["trackInfo"] = trackInfo.ToString();

            this.Model["albumId"] = albumId;

            return this.View();
        }
    }
}