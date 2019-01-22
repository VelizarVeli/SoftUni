namespace EventuresWebApp.Web.Filters
{
    using System;
    using Services.Interfaces;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class LogAdminActivityActionFilter : ActionFilterAttribute
    {
        private readonly IEventService service;
        private readonly ILogger logger;

        public LogAdminActivityActionFilter(IEventService service, ILogger<LogAdminActivityActionFilter> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var admin = context.HttpContext.User.Identity.Name;
            var lastEvent = this.service.Last();
            var logMessage = $"[{DateTime.Now}] Administrator {admin} create event {lastEvent.Name} ({lastEvent.Start} / {lastEvent.End})";
            this.logger.LogInformation(logMessage);
            base.OnActionExecuted(context);
        }
    }
}
