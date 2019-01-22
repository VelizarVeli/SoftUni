using System;
using Eventures.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Filters
{
    public class ActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public ActionFilter(ILogger<EventsController> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logMsg = $"[{DateTime.Now}] Administrator {context.HttpContext.User.Identity.Name} create event " +
                         $"{context.HttpContext.Request.Form["Name"]} ({context.HttpContext.Request.Form["Start"]} " +
                         $"/ {context.HttpContext.Request.Form["End"]}).";

            logger.LogInformation(logMsg);

            base.OnActionExecuting(context);
        }
    }
}
