using SIS.Framework.ActionResults;
using SIS.Framework.Attributes;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult GotIt()
        {
            return this.View();
        }
    }
}
