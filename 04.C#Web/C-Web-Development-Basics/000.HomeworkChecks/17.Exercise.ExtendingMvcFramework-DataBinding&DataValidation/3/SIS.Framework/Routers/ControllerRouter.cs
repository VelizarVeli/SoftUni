using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using RedirectResult = SIS.WebServer.Results.RedirectResult;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest httpRequest)
        {
            var requestUrlSplit = httpRequest.Url.Split("/", StringSplitOptions.RemoveEmptyEntries);

            var requestMethod = httpRequest.RequestMethod.ToString();
            var controllerName = requestUrlSplit[0];
            var actionName = requestUrlSplit[1];

            var controller = GetController(controllerName, httpRequest);
            MethodInfo action = this.GetMethod(requestMethod, controller, actionName);

            if (action == null)
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            object[] actionParameters = this.MapActionParameters(action, httpRequest, controller);

            IActionResult actionResult = this.InvokeAction(controller, action, actionParameters);

            return this.PrepareResponse(actionResult);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult) action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest httpRequest, Controller controller)
        {
            ParameterInfo[] actionParameterInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParameterInfo.Length];

            for (int index = 0; index < actionParameterInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParameterInfo[index];

                if (currentParameterInfo.ParameterType.IsPrimitive ||
                    currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[index] = ProcessPrimitiveParameter(currentParameterInfo, httpRequest);
                }
                else
                {
                    object bindingModel = ProcessBindingModelParameters(currentParameterInfo, httpRequest);
                    controller.ModelState.IsValid = this.IsValidModel(bindingModel);

                    mappedActionParameters[index] = bindingModel;
                }

            }

            return mappedActionParameters;
        }

        private bool IsValidModel(object bindingModel)
        {
            var properties = bindingModel.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(c => c is ValidationAttribute)
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

        private object ProcessBindingModelParameters(ParameterInfo param, IHttpRequest httpRequest)
        {
            Type bindingModelType = param.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(httpRequest, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped");
                
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest httpRequest)
        {
            object value = this.GetParameterFromRequestData(httpRequest, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest httpRequest, string paramName)
        {
            if (httpRequest.QueryData.ContainsKey(paramName)) return httpRequest.QueryData[paramName];
            if (httpRequest.FormData.ContainsKey(paramName)) return httpRequest.FormData[paramName];
            return null;
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

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
                throw new InvalidOperationException("The view result is not supported");
            }

        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach (var methodInfo in GetSuitableMethods(controller, actionName))
            {
                var attributes = methodInfo.GetCustomAttributes()
                    .Where(attr => attr is HttpMethodAttribute)
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
                .Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());
        }

        public static Controller GetController(string controllerName, IHttpRequest request)
        {
            if (controllerName != null)
            {
                var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
                    MvcContext.Get.AssemblyName,
                    MvcContext.Get.ControllersFolder,
                    (controllerName[0].ToString().ToUpper() + controllerName.Substring(1)),
                    MvcContext.Get.ControllerSuffix);


                
                
                var controllerType = Type.GetType(fullyQualifiedControllerName, true);
                
                
                if (controllerType == null) return null;

                var controller = (Controller) Activator.CreateInstance(controllerType);

                if (controller != null)
                {
                    controller.Request = request;
                }

                return controller;  
            }

            return null;
        }
    }
}
