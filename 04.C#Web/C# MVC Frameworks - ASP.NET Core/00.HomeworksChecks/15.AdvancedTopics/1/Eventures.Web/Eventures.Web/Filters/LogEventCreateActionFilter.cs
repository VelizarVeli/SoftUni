using Eventures.Web.ViewModels.Events;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Linq;

namespace Eventures.Web.Filters
{
    public class LogEventCreateActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;

        private CreateEventBindingModel model;

        public LogEventCreateActionFilter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<LogEventCreateActionFilter>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.model = (CreateEventBindingModel)context.ActionArguments.Values.Where(v => v is CreateEventBindingModel).FirstOrDefault();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(this.model != null)
            {
                string adminUsername = context.HttpContext.User.Identity.Name;

                string logMessage = $"{this.ParseDateTime(DateTime.Now)} " +
                    $"Administrator {adminUsername} " +
                    $"created event {model.Name} ({this.ParseDateTime(model.Start)} / {this.ParseDateTime(model.End)})";

                logger.LogInformation(logMessage);
            }

            base.OnActionExecuted(context);
        }

        private string ParseDateTime(DateTime date)
        {
            return date.ToString(@"dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
