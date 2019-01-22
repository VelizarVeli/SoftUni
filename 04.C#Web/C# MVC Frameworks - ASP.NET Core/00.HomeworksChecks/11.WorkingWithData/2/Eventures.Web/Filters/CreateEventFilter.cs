using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Filters
{
    public class CreateEventFilter : ActionFilterAttribute
    {
        private readonly ILogger<CreateEventFilter> logger;

        public CreateEventFilter(ILogger<CreateEventFilter> logger)
        {
            this.logger = logger;
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var adminName = context.HttpContext.User.Identity.Name;
            var eventName = context.HttpContext.Request.Form["Name"];
            var start = context.HttpContext.Request.Form["Start"];
            var end = context.HttpContext.Request.Form["End"];
            var logInfo = $"[{DateTime.UtcNow}] Administrator {adminName} create event {eventName} ({start} / {end})";
            this.logger.LogInformation(logInfo);
        }
    }
}
