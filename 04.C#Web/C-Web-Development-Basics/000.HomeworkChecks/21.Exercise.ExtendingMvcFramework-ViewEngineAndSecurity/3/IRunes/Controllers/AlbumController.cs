using IRunes.Extensions;
using IRunes.Models;
using IRunes.ViewModels.Album;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System;
using System.Linq;
using System.Text;

namespace IRunes.Controllers
{
    public class AlbumController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (this.User == null)
            {
                return this.View();
            }

            string name = model.Name;
            string cover = model.Cover;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cover))
            {
                return this.View();
            }

            var user = context.Users.FirstOrDefault(x => x.Username == this.User);

            if (user == null)
            {
                return this.View();
            }

            user.Albums.Add(new Album { Name = name, Cover = cover });
            this.context.SaveChanges();

            return this.RedirectToAction("/album/all");
        }

        [HttpGet]
        public IActionResult All()
        {
            this.Model["albums"] = "There are currently no albums.";

            string albumsParameters = null;
            
            if (this.User == null)
            {
                return this.View();
            }

            var user = this.context.Users.Include(x => x.Albums).FirstOrDefault(u => u.Username == this.User);

            if (user == null)
            {
                return this.View();
            }

            var albums = user.Albums.ToArray();

            foreach (var album in albums)
            {
                albumsParameters += $"<a href=\"/album/details?id={album.Id}\">{album.Name}</a></li><br/>";
            }

            if (albumsParameters != null)
            {
                this.Model["albums"] = albumsParameters;
            }
            

            return this.View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            var albumId = this.Request.QueryData["id"].ToString();

            var album = this.context.Albums.Include(x => x.Tracks).FirstOrDefault(x => x.Id == albumId);
            string albumCover = album.Cover.UrlDecode();

            var trackPrice = album.Tracks.Sum(x => x.Price);
            var totalPrice = trackPrice - (trackPrice * 13 / 100);

            var albumData = new StringBuilder();

            albumData.Append($"<img src=\"{albumCover}\" width=\"250\" height=\"250\"><br/>");
            albumData.Append($"<b>Name: {album.Name}</b><br/>");
            albumData.Append($"<b>Price: ${totalPrice}</b><br/>");

            var albumTracks = album.Tracks.ToArray();

            var tracks = new StringBuilder();

            this.Model["tracks"] = string.Empty;

            if (albumTracks.Length > 0)
            {
                foreach (var track in albumTracks)
                {
                    tracks.Append($"<a href=\"/track/details?id={track.Id}&albumId={albumId}\">{track.Name}</a></li><br/>");
                }

                this.Model["tracks"] = tracks.ToString();
            }

            this.Model["albumId"] = album.Id;
            this.Model["album"] = albumData.ToString();

            return this.View();
        }
    }
}