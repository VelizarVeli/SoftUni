using System;
using Services;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHashService hashService;

        public HomeController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        public IActionResult Index(IndexViewModel model)
        {
            var hashedUsername = this.hashService.Hash(model.Username);
            Console.WriteLine(hashedUsername);
            return this.View();
        }

    }
}
