using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Filters
{
    public class LogEventFilter : ActionFilterAttribute
    {
        private readonly ILogger<LogEventFilter> logger;

        public LogEventFilter(ILogger<LogEventFilter> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var adminName = context.HttpContext.User.Identity.Name;
            var eventName = context.HttpContext.Request.Form["Name"];
            var start = context.HttpContext.Request.Form["Start"];
            var end = context.HttpContext.Request.Form["End"];

            var logContent =
                $"{DateTime.UtcNow} Administrator {adminName} create event {eventName} ({start} / {end})";

            this.logger.LogInformation(logContent);
        }
    }
}
