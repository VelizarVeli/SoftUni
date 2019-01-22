namespace SIS.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using ActionResults.Contracts;
    using Attributes.Methods;
    using Controllers;
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using WebServer.Api;
    using WebServer.Results;

    public class ControllerRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            string controllerName = null;
            string actionName = null;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Path == "/" || request.Path == "/favicon.ico")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var parts = request.Path.Split("/", StringSplitOptions.RemoveEmptyEntries);
                controllerName = parts[0];
                actionName = parts[1];
            }

            var controller = this.GetController(controllerName, request);
            var action = this.GetMethod(requestMethod, controller, actionName);

            if (controller == null || action == null)
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var actionParameters = this.MapActionParameters(action, request, controller);
            var actionResult = this.InvokeAction(controller, action, actionParameters);

            return this.PrepareResponse(actionResult);
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (controllerName != null)
            {
                var controllerTypeName = string.Format("{0}.{1}.{2}{3}, {0}", 
                    MvcContext.Get.AssemblyName, MvcContext.Get.ControllersFolder, controllerName, MvcContext.Get.ControllersSuffix);

                var controllerType = Type.GetType(controllerTypeName);
                var controller = (Controller)Activator.CreateInstance(controllerType);

                if (controller != null)
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

            foreach (var methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                var attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper() == "GET")
                {
                    return methodInfo;
                }

                foreach (var attribute in attributes)
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
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name.ToLower() == actionName.ToLower());
        }

        private HttpResponse PrepareResponse(IActionResult actionResult)
        {
            var invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }
            else if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }
            else
            {
                throw new InvalidOperationException("The view result is not supported!");
            }
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest request, Controller controller)
        {
            var actionParametersInfo = action.GetParameters();
            var mappedActionParameters = new object[actionParametersInfo.Length];

            for (int i = 0; i < actionParametersInfo.Length; i++)
            {
                var currentParameterInfo = actionParametersInfo[i];
                if (currentParameterInfo.ParameterType.IsPrimitive || currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[i] = this.ProcessPrimitiveParameter(currentParameterInfo, request);
                }
                else
                {
                    var bindingModel = this.ProcessBindingModelParameters(currentParameterInfo, request);
                    controller.ModelState.IsValid = this.IsValidModel(bindingModel, currentParameterInfo.ParameterType);
                    mappedActionParameters[i] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValidModel(object bindingModel, Type parameterType)
        {
            var properties = parameterType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(p => p is ValidationAttribute)
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

        private object ProcessPrimitiveParameter(ParameterInfo currentParameterInfo, IHttpRequest request)
        {
            var value = this.GetParameterFromRequestData(request, currentParameterInfo.Name);
            return Convert.ChangeType(value, currentParameterInfo.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string name)
        {
            if (request.QueryData.ContainsKey(name))
            {
                return request.QueryData[name];
            }
            if (request.FormData.ContainsKey(name))
            {
                return request.FormData[name];
            }

            return null;
        }

        private object ProcessBindingModelParameters(ParameterInfo currentParameterInfo, IHttpRequest request)
        {
            var bindingModelType = currentParameterInfo.ParameterType;
            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    var value = this.GetParameterFromRequestData(request, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }
    }
}