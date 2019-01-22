using IRunes.Data;
using IRunes.Services;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;
using System.Collections.Generic;
using System.IO;

namespace IRunes.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IRunesDbContext context;
        
        protected BaseController()
        {
            this.context = new IRunesDbContext();
        }
        
        protected bool IsUserAuthenticated { get; set; } = false;
    }
}