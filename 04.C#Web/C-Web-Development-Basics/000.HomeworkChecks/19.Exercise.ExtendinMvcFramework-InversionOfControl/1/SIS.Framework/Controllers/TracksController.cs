namespace SIS.Framework.Controllers
{
    using ActionResults.Contracts;
    using Common;
    using Services.Contracts;
    using System;
    using System.Globalization;
    using ViewModels;

    public class TracksController : Controller
    {
        private readonly ITrackService trackService;

        public TracksController(ITrackService trackService)
        {
            this.trackService = trackService;
        }

        public IActionResult Create()
        {
            if (!this.IsAuthenticated())
            {
                return this.RedirectToAction("users/login");
            }

            return this.View();
        }

        public IActionResult Create(CreateTrackViewModel model)
        {
            var price = decimal.Parse(model.Price);

            var urlTokens = this.Request.Headers.GetHeader("Referer").Value.Split('?', StringSplitOptions.RemoveEmptyEntries);
            var albumId = urlTokens[1].Replace("albumId=", "");

            // Create
            this.trackService.CreateAndSaveTrack(model.Name, model.Link, price, albumId);

            this.ViewBag["albumId"] = $"?id={albumId}";

            return this.RedirectToAction("/tracks/create");
        }

        public IActionResult Details()
        {
            var urlTokens = this.Request.Url.Split('?', StringSplitOptions.RemoveEmptyEntries);
            var ids = urlTokens[1].Split('&', StringSplitOptions.RemoveEmptyEntries);
            var albumId = ids[0].Replace("albumid=", "");
            var trackId = ids[1].Replace("trackid=", "");
            var track = this.trackService.ById(trackId);
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
    }
}