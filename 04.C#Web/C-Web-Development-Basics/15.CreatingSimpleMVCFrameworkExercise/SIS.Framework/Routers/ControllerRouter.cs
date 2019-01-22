namespace SIS.Framework.Routers
{
    using Framework.ActionResults;
    using Framework.Attributes.Methods;
    using Framework.Controllers;
    using HTTP.Enums;
    using HTTP.Extensions;
    using HTTP.Requests;
    using HTTP.Responses;
    using WebServer.Api;
    using WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ControllerRouter : IHttpHandler
    {
        private Controller GetController(string controllerName)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            string fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
               MvcContext.Get.AssemblyName,
               MvcContext.Get.ControllersFolder,
               controllerName.Capitalize(),
               MvcContext.Get.ControllersSuffix);

            Type controllerType = Type.GetType(fullyQualifiedControllerName);

            if (controllerType == null)
            {
                return null;
            }
            Controller controller = (Controller)Activator.CreateInstance(controllerType);
            return controller;
        }
        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            var actions = this
                .GetSuitableMethods(controller, actionName)
                .ToList();
            if (!actions.Any())
            {
                return null;
            }
            foreach (var action in actions)
            {
                HttpMethodAttribute[] httpMethodAttributes = action
                    .GetCustomAttributes()
                    .Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToArray();

                if (!httpMethodAttributes.Any() &&
                   requestMethod.ToLower() == "get"
                   || httpMethodAttributes.Any(attribute => attribute.IsValid(requestMethod)))
                {
                    return action;
                }
            }
            return null;
        }
        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }
            return controller
               .GetType()
               .GetMethods()
               .Where(mi => mi.Name.ToLower() == actionName.ToLower());
        }
        private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
        {
            IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }
            if (actionResult is IRedirectable)
            {
                return new WebServer.Results.RedirectResult(invocationResult);
            }
            return null;
        }
        public IHttpResponse Handle(IHttpRequest request)
        {
            string requestMethod = request.RequestMethod.ToString();
            string controllerName;
            string actionName;

            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                string[] requestUrlSplit = request.Url.Split(
                    "/",
                    StringSplitOptions.RemoveEmptyEntries);
                if (requestUrlSplit.Length != 2)
                {
                    return null;
                }
                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }

            Controller controller = this.GetController(controllerName);
            MethodInfo action = this.GetMethod(requestMethod, controller, actionName);

            if (action == null)
            {
                return null;
            }
            return this.PrepareResponse(controller, action);
        }
    }
}
