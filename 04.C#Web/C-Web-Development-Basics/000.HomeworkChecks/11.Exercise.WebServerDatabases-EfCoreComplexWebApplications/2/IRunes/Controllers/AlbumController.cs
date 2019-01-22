using IRunes.Models;
using SIS.HTTP.Common;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.HTTP.Sessions;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IRunes.Controllers
{
    public class AlbumController : BaseController
    {
        public IHttpResponse All()
        {
            var albums = this.Db.Albums.Select(x => x.Name).ToList();
            
            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag)
            {
                {"Albums", string.Join($"{Environment.NewLine}",albums)}
            };

            return this.View("AllAlbums",viewBag);
        }
        public IHttpResponse Create()
        {
            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag);

            return this.View("CreateAlbum");
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag);

            var albumName = request.FormData["albumName"].ToString().Trim();
            //var albumPrice = decimal.Parse(request.FormData["price"].ToString());
            var albumCover = request.FormData["albumCover"].ToString().Trim();

            //Validation
            CoreValidator.ThrowIfNullOrEmpty(albumName, nameof(albumName));
            //CoreValidator.ThrowIfNullOrEmpty(albumPrice.ToString(), nameof(albumPrice));
            CoreValidator.ThrowIfNullOrEmpty(albumCover, nameof(albumCover));

            var album = new Album
            {
                Name = albumName,
                //Price = albumPrice,
                Cover = albumCover,
                Tracks = new List<Track>()
            };
            this.Db.Albums.Add(album);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            // Redirect
            return new RedirectResult("/");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            var id = request.QueryData["id"].ToString();
            var album = this.Db.Albums.FirstOrDefault(x => x.Id == id);
            if (album == null)
            {
                return this.BadRequestError("Album not found.");
            }

            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag)
            {
                {"Name", album.Name},
                {"Price", album.Price.ToString(CultureInfo.InvariantCulture)},
                {"Cover", album.Cover},
                {"Tracks",string.Join($"{Environment.NewLine}",album.Tracks) }
            };

            return this.View("AlbumDetails", viewBag);
        }
    }
}
