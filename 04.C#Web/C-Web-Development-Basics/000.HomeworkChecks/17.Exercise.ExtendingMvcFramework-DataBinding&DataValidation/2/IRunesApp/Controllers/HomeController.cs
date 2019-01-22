namespace IRunesApp.Controllers
{
    using SIS.HTTP.Responses.Contracts;
    using SIS.MVC.Framework.Attributes;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IHttpResponse Index()
        {
            if (this.IsAuthenticated())
            {
                this.ViewBag["username"] = this.Request.Session.GetParameter("username").ToString();

                return this.View("IndexLogged");
            }

            return this.View();
        }
    }
}