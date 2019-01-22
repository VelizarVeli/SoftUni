using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.Framework.Attributes.Action;
using SIS.Framework.Controllers;
using SIS.Framework.Services.Contracts;
using SIS.HTTP.Extensions;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SIS.Framework.Routes
{
    public class ControllerRouter : IHttpHandler
    {
        private readonly IDependencyContainer dependencyContainer;

        public ControllerRouter(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Path == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Path.Split("/", StringSplitOptions.RemoveEmptyEntries);

                if (requestUrlSplit.Length >= 2)
                {

                    controllerName = requestUrlSplit[0];
                    actionName = requestUrlSplit[1];
                }
            }

            var controller = this.GetController(controllerName, request);
            
            var action = this.GetMethod(requestMethod, controller, actionName);

            if (controller == null || action == null)
            {
                throw new NullReferenceException();
            }

            controller.Request = request;

            object[] actionParameters = this.MapActionParameters(action, request, controller);

            var actionResult = InvokeAction(controller, action, actionParameters);

            var response = this.PrepareResponse(actionResult);

            foreach (var cookie in controller.Cookies)
            {
                response.AddCookie(cookie);
            }

            return this.Authorize(controller, action) ?? response;
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest request, Controller controller)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for (int index = 0; index < actionParametersInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParametersInfo[index];

                if (currentParameterInfo.ParameterType.IsPrimitive || currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[index] = ProcessPrimitiveParameter(currentParameterInfo, request);
                }
                else
                {
                    var bindingModel = this.ProcessBindingModelParameters(currentParameterInfo, request);
                    controller.ModelState.IsValid = this.IsValid(bindingModel,currentParameterInfo.ParameterType);
                    mappedActionParameters[index] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValid(object bindingModel, Type parameterType)
        {
            var properties = parameterType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToList();

                foreach (var validationAttribute in propertyValidationAttributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest request)
        {
            object value = this.GetParameterFromRequestData(request, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string name)
        {
            if (request.QueryData.Any(x => x.Key.ToLower() == name.ToLower())) return request.QueryData[name.ToLower()];
            if (request.FormData.Any(x => x.Key.ToLower() == name.ToLower())) return request.FormData[name.ToLower()];

            return null;
        }

        private object ProcessBindingModelParameters(ParameterInfo param, IHttpRequest request)
        {
            Type bindingModelType = param.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(request, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(HTTP.Enums.HttpResponseStatusCode.Ok, invocationResult);
            }

            if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException($"The {invocationResult} is not supported.");
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
                var httpMethodAttributes = action
                    .GetCustomAttributes()
                    .Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToList();

                if (!httpMethodAttributes.Any() && requestMethod.ToLower() == "get")
                {
                    return action;
                }

                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(requestMethod))
                    {
                        return action;
                    }
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

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName.Capitalize(),
                MvcContext.Get.ControllersSuffix);

            var controllerType = Type.GetType(fullyQualifiedControllerName);

            var controller = (Controller)Activator.CreateInstance(controllerType);
            return controller;
        }

        private IHttpResponse Authorize(Controller controller, MethodInfo action)
        {
            if (action.GetCustomAttributes()
                .Where(a => a is AuthorizeAttribute)
                .Cast<AuthorizeAttribute>()
                .Any(a => !a.IsAuthorized(controller.Identity)))
            {
                return new UnauthorizedResult();
            }

            return null;
        }
    }
}