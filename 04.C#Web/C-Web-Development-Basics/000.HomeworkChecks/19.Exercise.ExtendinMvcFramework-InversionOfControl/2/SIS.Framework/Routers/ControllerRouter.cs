using SIS.Framework.ActionResults.Base;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes.Methods.Base;
using SIS.Framework.Controllers;
using SIS.Framework.Services.Contracts;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Contracts;
using SIS.WebServer.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHttpHandler
    {
        private readonly IHttpHandler resourceHandler;

        private readonly IDependencyContainer dependencyContainer;

        public ControllerRouter(IDependencyContainer dependencyContainer)
        {
            this.resourceHandler = new ResourceRouter();
            this.dependencyContainer = dependencyContainer;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request))
            {
                return this.resourceHandler.Handle(request);
            }

            var actionName = string.Empty;
            var controllerName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Path == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Path.Split("/", StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestUrlSplit[0].Capitalize();
                actionName = requestUrlSplit[1].Capitalize();
            }

            var controller = this.GetController(controllerName, request);

            var action = this.GetAction(requestMethod, controller, actionName);

            if (controller == null || action == null)
            {
                throw new NullReferenceException();
            }

            var actionParamaters = this.MapActionParameters(action, request, controller);

            var actionResult = InvokeAction(controller, action, actionParamaters);

            return this.PrepareResponse(actionResult);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains("."))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf("."));
                return ((IList)GlobalConstants.ReosurceExtensions).Contains(requestPathExtension);
            }

            return false;
        }

        private static IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            var actionResult = (IActionResult)action.Invoke(controller, actionParameters);
            return actionResult;
        }

        private MethodInfo GetAction(string requestMethod, Controller controller, string actionName)
        {
            var actions = this.GetSuitableMethods(controller, actionName).ToList();

            if (!actions.Any())
            {
                return null;
            }

            foreach (var action in actions)
            {
                var httpMethodAttributes = action.GetCustomAttributes().Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>().ToList();

                if (!httpMethodAttributes.Any() || requestMethod.ToLower() == "get")
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

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            var fullyQualifiedControllerName = string.Format(
                "{0}.{1}.{2}{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName,
                MvcContext.Get.ControllerSuffix);

            var controllerType = Type.GetType(fullyQualifiedControllerName);
            var controller = (Controller)this.dependencyContainer.CreateInstance(controllerType);

            if (controller != null)
            {
                controller.Request = request;
            }

            return controller;
        }

        private object GetParameterFromRequestData(IHttpRequest request, string actionParameterName)
        {
            if (request.QueryData.ContainsKey(actionParameterName))
            {
                return request.QueryData[actionParameterName];
            }

            if (request.FormData.ContainsKey(actionParameterName))
            {
                return request.FormData[actionParameterName];
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller.GetType().GetMethods().Where(mi => mi.Name.ToLower() == actionName.ToLower());
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest request, Controller controller)
        {
            var actionParameters = action.GetParameters();
            var mappedActionParameters = new object[actionParameters.Length];

            for (var i = 0; i < actionParameters.Length; i++)
            {
                var actionParameter = actionParameters[i];

                if (actionParameter.ParameterType.IsPrimitive || actionParameter.ParameterType == typeof(string))
                {
                    var mappedActionParameter = this.ProcessPrimitiveParameter(actionParameter, request);

                    if (mappedActionParameter == null)
                    {
                        break;
                    }

                    mappedActionParameters[i] = mappedActionParameter;
                }
                else
                {
                    var bindingModel = this.ProcessBindingModelParameter(actionParameter, request);
                    controller.ModelState.IsValid = this.IsValid(bindingModel, actionParameter.ParameterType);
                    mappedActionParameters[i] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValid(object bindingModel, Type bindingModelType)
        {
            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property.GetCustomAttributes().Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>().ToList();

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

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            var invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }

            if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException("The view result is not supported.");
        }

        private object ProcessBindingModelParameter(ParameterInfo actionParameter, IHttpRequest request)
        {
            var bindingModelType = actionParameter.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);

            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var bindingModelProperty in bindingModelProperties)
            {
                try
                {
                    var value = this.GetParameterFromRequestData(request, bindingModelProperty.Name.ToLower());
                    bindingModelProperty.SetValue(
                        bindingModelInstance,
                        Convert.ChangeType(value, bindingModelProperty.PropertyType));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"The property {bindingModelProperty.Name} could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo actionParameter, IHttpRequest request)
        {
            var value = this.GetParameterFromRequestData(request, actionParameter.Name.ToLower());

            if (value == null)
            {
                return value;
            }

            return Convert.ChangeType(value, actionParameter.ParameterType);
        }
    }
}
