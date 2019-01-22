namespace Eventures.Web.Filters
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using ViewModels.Events;

    public class EventsCreateLogActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;
        private EventCreateViewModel eventCreateViewModel;

        public EventsCreateLogActionFilter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<EventsCreateLogActionFilter>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.eventCreateViewModel = context.ActionArguments.Values.OfType<EventCreateViewModel>().Single();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (this.eventCreateViewModel != null)
            {
                var dateNow = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm");
                var adminName = context.HttpContext.User.Identity.Name;
                var eventName = this.eventCreateViewModel.Name;
                var eventStart = this.eventCreateViewModel.Start.ToString("dd/MM/yyyy HH:mm");
                var eventEnd = this.eventCreateViewModel.End.ToString("dd/MM/yyyy HH:mm");

                this.logger.LogInformation($"[{dateNow}] Administrator {adminName} create event {eventName} ({eventStart} / {eventEnd}).");
            }

            base.OnActionExecuted(context);
        }
    }
}
