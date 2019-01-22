namespace SIS.Framework.Controllers
{
    using ActionResults.Contracts;
    using ViewModels;

    public class HomeController : Controller
    {
        //public IHttpResponse Index()
        //{
        //    if (this.IsAuthenticated())
        //    {
        //        var username = this.Request.Session.GetParameter("username");
        //        this.ViewBag["username"] = username.ToString();

        //        return this.View("IndexLogged");
        //    }

        //    return this.ViewMethod();
        //}

        public IActionResult Index(IndexViewModel model)
        {
            return this.View();
        }
    }
}