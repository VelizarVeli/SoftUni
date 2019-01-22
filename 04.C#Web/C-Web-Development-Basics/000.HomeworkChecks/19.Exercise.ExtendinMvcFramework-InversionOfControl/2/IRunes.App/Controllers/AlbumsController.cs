using IRunes.Models.ViewModels.Albums;
using IRunes.Services.Contracts;
using SIS.Framework.ActionResults.Base;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            var result = new StringBuilder();

            var albums = this.albumService.GetAllAlbums();

            if (albums.Count == 0)
            {
                result.Append("<em>There are currently no albums.</em>");
            }

            else
            {
                foreach (var album in albums)
                {
                    result.AppendLine($"<strong><a href=\"/Albums/Details?id={album.Id}\">{album.Name}</a></strong><br>");
                }
            }

            this.ViewModel["Albums"] = result.ToString();

            return this.View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AlbumViewModel model)
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            this.albumService.CreateAlbum(model);

            return this.RedirectToAction("/Albums/All");
        }

        [HttpGet]
        public IActionResult Details(AlbumViewModel model)
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            var album = this.albumService.GetAlbumById(model.Id);

            var result = new StringBuilder();

            var tracks = this.albumService.GetAlbumTracks(album.Id).ToArray();

            if (tracks.Length == 0)
            {
                result.Append("<em>There are no tracks in this album!</em>");
            }
            else
            {
                result.Append("<ul>");
                var index = 1;
                foreach (var track in tracks)
                {
                    result.AppendLine($"<li><strong>{index}. </strong><em><a href=\"/Tracks/Details?id={track.Id}\">{track.Name}</a></em></li>");
                    index++;
                }

                result.Append("</ul>");
            }

            var price = this.albumService.GetPrice(album.Id);

            this.ViewModel["CoverUrl"] = album.Cover;
            this.ViewModel["Name"] = album.Name;
            this.ViewModel["Price"] = price.ToString("F2");
            this.ViewModel["Tracks"] = result.ToString();
            this.ViewModel["AlbumId"] = album.Id;

            return this.View();
        }
    }
}
