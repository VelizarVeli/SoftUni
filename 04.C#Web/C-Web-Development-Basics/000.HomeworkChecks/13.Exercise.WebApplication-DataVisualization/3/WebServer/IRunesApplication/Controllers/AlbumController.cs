namespace WebServer.IRunesApplication.Controllers
{
    using System.Text;
    using System.Linq;
    using Services;
    using Services.Contracts;
    using Server.Http.Contracts;
    using ViewModels.Product;

    public class AlbumController : BaseController
    {
        private readonly IProductService products;

        public AlbumController(IHttpRequest request)
            : base(request)
        {
            this.products = new ProductService();
        }
        public IHttpResponse All()
        {
            var listOfAlbums = products.All().ToList();

            var sb = new StringBuilder();
            sb.AppendLine("<div>");

            foreach (var item in listOfAlbums)
            {
                sb.AppendLine($@"<p><a href=""/Albums/Details/{item.Id}"">{item.Name}</a></p>");
            }
            sb.AppendLine("</div>");

            this.ViewData["anonymousUser"] = "none";
            this.ViewData["loggedUser"] = "block";
            this.ViewData["albumsContent"] = sb.ToString();
            return this.FileViewResponse(@"products\list");
        } 

        public IHttpResponse Add()
        {
            return this.FileViewResponse(@"products/add");
        }

        public IHttpResponse Add(AddProductViewModel model)
        {
            products.Create(model.Name, model.Url);
            return this.All();
        }

        public IHttpResponse Details(int id)
        {
            var album = products.Find(id);
            this.ViewData["anonymousUser"] = "none";
            this.ViewData["loggedUser"] = "block";
            
            this.ViewData["album-id"] = $"{id}";
            this.ViewData["image-url"] = album.ImageUrl;
            this.ViewData["album-name"] = album.Name;
            this.ViewData["album-price"] = $"{album.Price:f2}";

            if (album.Tracks.Count !=0)
            {
                this.ViewData["tracks"] = "block";
                var sb = new StringBuilder();
                foreach (var track in album.Tracks)
                {
                    sb.AppendLine($@"<li><a href=""/Tracks/Details/{id}/{track.Id}"">{track.Name}</a></li>");
                }
                this.ViewData["content-album"] = sb.ToString();
            }
            else
            {
                this.ViewData["tracks"] = "none";
            }
            return this.FileViewResponse(@"products/details");
        }
    }
}
