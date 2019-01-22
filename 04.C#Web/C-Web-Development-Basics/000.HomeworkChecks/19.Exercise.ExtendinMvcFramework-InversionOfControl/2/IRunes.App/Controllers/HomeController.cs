using SIS.Framework.ActionResults.Base;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App.Controllers
{
    [HttpGet]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.Request.IsLoggedIn())
            {
                this.ViewModel["Username"] = this.Request.GetUsername();
            }

            return this.View();
        }
    }
}
