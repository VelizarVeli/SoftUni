namespace EventWebApp.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            // throw new Exception("Try to log error exception in db");

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }


    }
}
