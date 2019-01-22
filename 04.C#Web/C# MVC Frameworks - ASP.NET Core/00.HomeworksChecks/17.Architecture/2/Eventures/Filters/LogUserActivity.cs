using Eventures.Services.EventService;
using Eventures.Services.EventService.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Filters
{
    public class LogUserActivity : ActionFilterAttribute
    {
        private readonly IEventService eventService;

        public LogUserActivity(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
