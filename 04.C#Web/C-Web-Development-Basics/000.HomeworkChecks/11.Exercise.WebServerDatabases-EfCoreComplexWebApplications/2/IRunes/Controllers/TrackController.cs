using IRunes.Models;
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
    public class TrackController : BaseController
    {
        public IHttpResponse Create()
        {
            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag);

            return this.View("CreateTrack");
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag);

            var trackName = request.FormData["trackName"].ToString().Trim();
            var trackPrice = decimal.Parse(request.FormData["trackPrice"].ToString());
            var trackLink = request.FormData["trackLink"].ToString().Trim();

            // TODO: Validation

            var track = new Track
            {
                Name = trackName,
                Price = trackPrice,
                Link = trackLink
            };
            this.Db.Tracks.Add(track);

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
            var track = this.Db.Tracks.FirstOrDefault(x => x.Id == id);
            if (track == null)
            {
                return this.BadRequestError("Track not found.");
            }

            var viewBag = new Dictionary<string, string>(HttpSessionStorage.UserViewBag)
            {
                {"Name", track.Name},
                {"Price", track.Price.ToString(CultureInfo.InvariantCulture)},
                {"Link", track.Link}
            };

            return this.View("TrackDetails",viewBag);
        }
    }
}
