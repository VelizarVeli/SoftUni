using SIS.Framework.ActionResults;
using SIS.Framework.Attributes;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHttpHandler
    {
        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (controllerName!=null)
            {
                string controllerTypeName = string.Format("{0}.{1}.{2}, {0}",
                    MvcContext.Get.AssemblyName,
                    MvcContext.Get.ControllersFolder,
                    controllerName + MvcContext.Get.ControllersSuffix);

                Type controllerType = Type.GetType(controllerTypeName);
                Controller controller = (Controller)Activator.CreateInstance(controllerType);
                if (controller!=null)
                {
                    controller.Request = request;
                }

                return controller;
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods(controller,actionName))
            {
                IEnumerable<HttpMethodAttribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(attr => attr is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper()=="GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller==null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
        {
            IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }
            else if (actionResult is IRedirectable)
            {
                return new WebServer.Results.RedirectResult(invocationResult);
            }
            else
            {
                throw new InvalidOperationException("This view result is not supported.");
            }
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();
            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Url.Split(
                    "/",
                    StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }
            // var result = new Controller.Action();
            // handle => result
            //Controller
            var controller = this.GetController(controllerName, request);
            //Action
            var action = this.GetMethod(requestMethod, controller, actionName);
            if (controller == null || action == null)
            {
                throw new NullReferenceException();
            }
            return this.PrepareResponse(controller, action);
        }
    }
}
