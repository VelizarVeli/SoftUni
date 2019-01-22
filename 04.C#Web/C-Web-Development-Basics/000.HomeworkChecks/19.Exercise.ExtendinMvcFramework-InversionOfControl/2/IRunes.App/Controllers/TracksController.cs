using IRunes.Models.ViewModels.Tracks;
using IRunes.Services.Contracts;
using SIS.Framework.ActionResults.Base;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService trackService;

        public TracksController(ITrackService trackService)
        {
            this.trackService = trackService;
        }

        [HttpGet]
        public IActionResult Create(AlbumIdViewModel model)
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            this.ViewModel["AlbumId"] = model.AlbumId;

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(TrackViewModel model)
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            if (!decimal.TryParse(model.Price, out decimal price))
            {
                return this.View();
            }

            this.trackService.CreateTrack(model, price);

            return this.RedirectToAction("/Albums/Details?id=" + model.AlbumId);
        }

        [HttpGet]
        public IActionResult Details(TrackViewModel model)
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            TrackViewModel track = this.trackService.GetTrackById(model.Id);

            this.ViewModel["Name"] = track.Name;
            this.ViewModel["Link"] = track.Link.Replace("watch?v=", "embed/");
            this.ViewModel["AlbumId"] = track.AlbumId;
            this.ViewModel["Price"] = track.Price;

            return this.View();
        }
    }
}
