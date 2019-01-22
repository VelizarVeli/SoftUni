using System;
using System.Collections.Generic;
using System.Text;
using IRunesWebApp.Models;
using Microsoft.EntityFrameworkCore.Internal;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IRunesWebApp.Controllers
{
    public class AlbumsController : BaseController
    {
        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }
            var albums = this.Context.Albums;
            var listOfAlbums = string.Empty;
            if (albums.Any())
            {
                var albumHtml = string.Empty;
                foreach (var album in albums)
                {
                    albumHtml = $"<h3><a class=\"text-lightblue\" href = \"/albums/details?id={album.Id}\">{album.Name}</a></h3>";
                    listOfAlbums += albumHtml;
                }

                this.ViewBag["albumsList"] = listOfAlbums;
            }
            else
            {
                this.ViewBag["albumsList"] = "There are currently no albums.";
            }


            return this.ViewMethod();

        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }
            if (!request.QueryData.ContainsKey("id"))
            {
                return new BadRequestResult("No album id specified", HttpResponseStatusCode.BadRequest);
            }

            var albumId = request.QueryData["id"].ToString();
            var albums = this.Context.Albums;
            Album album = albums.FirstOrDefault(a => a.Id == albumId);
            

            if (album == null)
            {
                return new BadRequestResult("Album not found", HttpResponseStatusCode.NotFound);
            }

            this.ViewBag["coverImageUrl"] = $"{album.Cover}";
            this.ViewBag["albumName"] = $"{album.Name}";
            this.ViewBag["albumPrice"] = $"${album.Price:F2}";
            this.ViewBag["albumId"] = $"{albumId}";
            var tracks = album.Tracks;
            string tracksHTML = string.Empty;
            foreach (var track in tracks)
            {
                string temp = $"<li><a class=\"text-lightblue\" href = \"/tracks/details?albumId={albumId}&trackId={track.Id}\"><i>{track.Name}</i></a></li>";
                tracksHTML += temp;
            }
            this.ViewBag["tracksList"] = tracksHTML;
            return this.ViewMethod();
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            return this.ViewMethod();
        }

        public IHttpResponse PostCreate(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            string name = request.FormData["name"].ToString();
            string cover = request.FormData["cover"].ToString();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(cover))
            {
                return new BadRequestResult("Name and cover cannot be empty", HttpResponseStatusCode.BadRequest);
            }

            Album album = new Album
            {
                Name = name,
                Cover = cover
            };

            this.Context.Albums.Add(album);
            this.Context.SaveChanges();

            return new RedirectResult("/albums/all");
        }
    }
}

