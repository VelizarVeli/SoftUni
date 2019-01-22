namespace WebServer.IRunesApplication.Controllers
{
    using Server.Http.Contracts;
    using WebServer.Server.Http;

    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest request) 
            : base(request)
        {
        }

        public IHttpResponse Index()
        {
            this.ViewData["anonymousUser"] = "block";
            this.ViewData["loggedUser"] = "none";
            this.ViewData["authDisplay"] = "none";        
            this.ViewData["welcome"] = "none";
            return this.FileViewResponse(@"Home/Index");
        }

        public IHttpResponse IndexLogged()
        {
            var name = Request.Session.Get<string>(SessionStore.CurrentUserKey);
            this.ViewData["name"] = name;
            this.ViewData["anonymousUser"] = "none";
            this.ViewData["loggedUser"] = "block";
            this.ViewData["authDisplay"] = "none";
            this.ViewData["welcome"] = "block";
            this.ViewData["welcome-btn"] = "none";
            return this.FileViewResponse(@"Home/Index");
        }
    }
}
