namespace SIS.Framework.Routers
{
    using ActionResults.Contracts;
    using Attributes.Methods;
    using Common;
    using Controllers;
    using HTTP.Enums;
    using HTTP.Extensions;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using WebServer.Results;
    using WebServer.Routing.Contracts;

    public class ControllerRouter : IHttpHandler
    {
        private readonly IDependencyContainer container;

        public ControllerRouter(IDependencyContainer container)
        {
            this.container = container;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            if (request.Url == "/")
            {
                controllerName = Constants.DefaultControllerName;
                actionName = Constants.DefaultActionName;
            }
            else
            {
                var urlTokens = request.Url.Split('/', StringSplitOptions.RemoveEmptyEntries);
                if (urlTokens.Length >= 2)
                {
                    controllerName = urlTokens[0].Capitalise();
                    actionName = urlTokens[1].Capitalise();
                }
            }

            var controller = this.GetController(controllerName, request);
            var action = this.GetMethod(request.RequestMethod.ToString(), controller, actionName);
            if (controller == null || action == null)
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var actionParams = this.MapActionParams(controller, action, request);
            var actionResult = this.InvokeAction(controller, action, actionParams);

            return this.PrepareResponse(actionResult);
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

            throw new InvalidOperationException(Constants.NotSupportedView);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParams)
        {
            return (IActionResult)action.Invoke(controller, actionParams);
        }

        private object[] MapActionParams(Controller controller, MethodInfo action, IHttpRequest request)
        {
            var actionParamsInfo = action.GetParameters();
            var mappedActionParams = new object[actionParamsInfo.Length];
            for (int i = 0; i < actionParamsInfo.Length; i++)
            {
                var currentParamsInfo = actionParamsInfo[i];
                if (currentParamsInfo.ParameterType.IsPrimitive
                    || currentParamsInfo.ParameterType == typeof(string))
                {
                    mappedActionParams[i] = this.ProcessPrimitiveParams(currentParamsInfo, request);
                }
                else
                {
                    var bindingModel = this.ProcessBindingModelParams(currentParamsInfo, request);
                    controller.ModelState.IsValid = this.isValidModel(bindingModel);
                    mappedActionParams[i] = bindingModel;
                }
            }

            return mappedActionParams;
        }

        private bool isValidModel(object bindingModel)
        {
            var bindingModelProps = bindingModel.GetType().GetProperties();
            foreach (var prop in bindingModelProps)
            {
                var propValidationAttrs = prop.GetCustomAttributes().Where(a => a is ValidationAttribute).Cast<ValidationAttribute>().ToArray();
                if (propValidationAttrs.Any())
                {
                    foreach (var attr in propValidationAttrs)
                    {
                        var propValue = prop.GetValue(bindingModel);
                        if (!attr.IsValid(propValue))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private object ProcessBindingModelParams(ParameterInfo param, IHttpRequest request)
        {
            var bindingModelType = param.ParameterType;
            var bindingModel = Activator.CreateInstance(bindingModelType);
            var bindingModelProps = bindingModelType.GetProperties();
            foreach (var prop in bindingModelProps)
            {
                try
                {
                    var value = this.GetParameterFromRequestData(request, prop.Name);
                    prop.SetValue(bindingModel, Convert.ChangeType(value, prop.PropertyType));
                }
                catch
                {
                    Console.WriteLine(String.Format(Messages.FieldCannotBeMapped, prop.Name));
                }
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private object ProcessPrimitiveParams(ParameterInfo param, IHttpRequest request)
        {
            var value = this.GetParameterFromRequestData(request, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string paramName)
        {
            if (request.QueryData.ContainsKey(paramName))
            {
                return request.QueryData[paramName];
            }

            if (request.FormData.ContainsKey(paramName))
            {
                return request.FormData[paramName];
            }

            return null;
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            var assemblyName = MvcContext.Get.AssemblyName;
            // Assembly.GetExecutingAssembly().GetName();
            var controllersFolder = MvcContext.Get.ControllersFolder;
            var controllerType = Type.GetType($"{assemblyName.Name}.{controllersFolder}.{controllerName}{Constants.ControllerSuffix}, {assemblyName}");
            var controller = (Controller)this.container.CreateInstance(controllerType);
            if (controller != null)
            {
                controller.Request = request;
            }

            return controller;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            var actions = this.GetSuitableMethods(controller, actionName).ToArray();
            if (!actions.Any())
            {
                return null;
            }

            foreach (var action in actions)
            {
                var attributes = action.GetCustomAttributes().Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>().ToArray();
                if (!attributes.Any() && requestMethod.ToUpper() == "GET")
                {
                    return action;
                }

                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
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

            return controller.GetType().GetMethods().Where(m => m.Name.ToLower() == actionName.ToLower());
        }
    }
}