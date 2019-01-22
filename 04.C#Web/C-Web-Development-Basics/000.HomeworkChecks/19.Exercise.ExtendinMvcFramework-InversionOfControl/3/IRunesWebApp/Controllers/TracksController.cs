using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IRunesWebApp.Models;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class TracksController : BaseController
    {
        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }
            if (!request.QueryData.ContainsKey("albumId"))
            {
                return new BadRequestResult("No album id specified", HttpResponseStatusCode.BadRequest);
            }

            var albumId = request.QueryData["albumId"].ToString();

            if (!this.Context.Albums.Any(a => a.Id == albumId))
            {
                return new BadRequestResult("Album not found", HttpResponseStatusCode.BadRequest);
            }

            this.ViewBag["albumId"] = albumId;

            return this.ViewMethod();
        }

        public IHttpResponse PostCreate(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            string name = request.FormData["name"].ToString();
            string link = request.FormData["link"].ToString();
            string priceString = request.FormData["price"].ToString();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(link) ||
                string.IsNullOrWhiteSpace(priceString))
            {
                return new BadRequestResult("Name, link and price cannot be empty", HttpResponseStatusCode.BadRequest);
            }

            if (!decimal.TryParse(priceString, out decimal price))
            {
                return new BadRequestResult("Invalid price", HttpResponseStatusCode.BadRequest);
            }

            const string pattern = @"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)";
            const string replacement = "http://www.youtube.com/embed/$1";

            var rgx = new Regex(pattern);
            var newLink = rgx.Replace(link, replacement);
            link = newLink;

            var albumId = request.QueryData["albumId"].ToString();
            Album album = this.Context.Albums.FirstOrDefault(a => a.Id == albumId);
            album.Price = (album.Tracks.Sum(t => t.Price) + price) * Convert.ToDecimal(0.87);
            Track track = new Track
            {
                Name = name,
                Album = album,
                AlbumId = albumId,
                Link = link,
                Price = price
                
                
            };
            
            this.Context.Tracks.Add(track);
            this.Context.SaveChanges();

            
            return new RedirectResult($"/albums/details?id={albumId}");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            if (!request.QueryData.ContainsKey("trackId"))
            {
                return new BadRequestResult("No track id specified", HttpResponseStatusCode.BadRequest);
            }

            var trackId = request.QueryData["trackId"].ToString();

            Track track = this.Context.Tracks.FirstOrDefault(a => a.Id == trackId);

            if (track == null)
            {
                return new BadRequestResult("Track not found.", HttpResponseStatusCode.BadRequest);
            }
            
            this.ViewBag["trackName"] = track.Name;
            this.ViewBag["trackLink"] = track.Link;
            this.ViewBag["albumId"] = track.AlbumId;
            this.ViewBag["trackPrice"] = track.Price.ToString("F2");
            return this.ViewMethod();
        }
    }
}
