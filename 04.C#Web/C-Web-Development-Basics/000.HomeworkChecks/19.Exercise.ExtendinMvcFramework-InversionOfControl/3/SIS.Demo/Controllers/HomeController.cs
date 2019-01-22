using System;
using System.Collections.Generic;
using System.Text;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace SIS.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
