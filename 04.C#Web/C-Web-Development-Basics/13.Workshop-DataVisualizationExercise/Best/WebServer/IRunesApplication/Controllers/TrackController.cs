namespace WebServer.IRunesApplication.Controllers
{
    using ViewModels.Product;
    using Server.Http.Contracts;
    using Services;
    using Services.Contracts;
    using System;
    using System.Text;

    public class TrackController : BaseController
    {
        private readonly ITrackService tracks;
        private readonly IProductService products;

        public TrackController(IHttpRequest request) 
            : base(request)
        {
            this.tracks = new TrackService();
            this.products = new ProductService();
        }

        public IHttpResponse Create(int albumId)
        {
            this.ViewData["anonymousUser"] = "none";
            this.ViewData["loggedUser"] = "block";
            this.ViewData["album-id"] = $"{albumId}";

            return this.FileViewResponse(@"tracks/add-track");
        }

        public IHttpResponse Create(AddTrackViewModel model, int albumId)
        {
            tracks.Create(model.Name, model.Link, model.Price, albumId);

            var album = products.Find(albumId);
            this.ViewData["anonymousUser"] = "none";
            this.ViewData["loggedUser"] = "block";

            this.ViewData["album-id"] = $"{albumId}";
            this.ViewData["image-url"] = album.ImageUrl;
            this.ViewData["album-name"] = album.Name;
            this.ViewData["album-price"] = $"{album.Price:f2}";

            if (album.Tracks.Count != 0)
            {
                this.ViewData["tracks"] = "block";
                var sb = new StringBuilder();
                foreach (var track in album.Tracks)
                {
                    sb.AppendLine($@"<li><a href=""/Tracks/Details/{track.Id}"">{track.Name}</a></li>");
                }
                this.ViewData["content-album"] = sb.ToString();
            }
            else
            {
                this.ViewData["tracks"] = "none";
            }
            return this.FileViewResponse(@"products/details");
        }

        public IHttpResponse Details(int albumId, int trackId)
        {
            var track = tracks.Find(trackId, albumId);
            var videoLink = track.videoLink.Replace("watch?v=", "embed/");
            this.ViewData["video-link"] = videoLink;
            this.ViewData["track-name"] = track.Name;
            this.ViewData["track-price"] = $"{track.Price:f2}";
            this.ViewData["album-id"] = albumId.ToString();
            this.ViewData["loggedUser"] = "block";
            this.ViewData["anonymousUser"] = "none";

            return this.FileViewResponse(@"tracks/details");
        }
    }
}
