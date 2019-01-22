namespace Eventures.WebApp.Extentions
{
    using System;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class LogCreateActionFilter : ActionFilterAttribute
    {
        public LogCreateActionFilter(ILogger<LogCreateActionFilter> logger)
        {
            this.Logger = logger;
        }

        private ILogger<LogCreateActionFilter> Logger { get; }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var user = context.HttpContext.User.Identity.Name;
            var eventName = context.HttpContext.Request.Form["Name"].ToString();
            var eventStart = context.HttpContext.Request.Form["Start"].ToString();
            var eventEnd = context.HttpContext.Request.Form["End"].ToString();

            string message = $"{DateTime.UtcNow} Administrator {user} create event {eventName} ({eventStart} / {eventEnd}).";
            this.Logger.LogInformation(message);
        }
    }
}