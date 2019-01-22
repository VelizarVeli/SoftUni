using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Web.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Filters
{
    public class LogAdminActivityFilter : ActionFilterAttribute
    {
        private readonly IDataService dataService;
        private readonly ILogger<LogAdminActivityFilter> logger;

        public LogAdminActivityFilter(
            IDataService dataService, ILogger<LogAdminActivityFilter> logger)
        {
            this.dataService = dataService;
            this.logger = logger;
        }
       
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var userName = context.HttpContext.User.Identity.Name;
            var eventureEvent = this.dataService.GetLastCreatedEvent();
            var eventName = eventureEvent.Name;
            var eventStart = eventureEvent.Start;
            var eventEnd = eventureEvent.End;
            var logMessage = $"[{DateTime.Now}] Administrator {userName} create event {eventName} ( {eventStart} / {eventEnd} ).";
            logger.LogInformation(logMessage);

        }
    }
}


