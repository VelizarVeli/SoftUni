namespace SIS.Framework.Routers
{
    using ActionResults.Contracts;
    using Attributes.Methods;
    using Controllers;
    using HTTP.Enums;
    using HTTP.Extensions;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using WebServer.Api.Contracts;
    using WebServer.Results;

    public class ControllerRouter : IHttpHandler
    {
        private const string Controller = "Controller";

        private const string HomeController = "HomeController";

        private const string IndexAction = "Index";

        public IHttpResponse Handle(IHttpRequest request)
        {
            // Getting request method
            string requestMethod = request.RequestMethod.ToString();
            
            // Getting controller name and action name
            string controllerName;
            string actionName;
            string[] pathArgs = request.Path.ToLower().Split('/', StringSplitOptions.RemoveEmptyEntries);
            
            if(pathArgs.Length == 0)
            {
                controllerName = HomeController;
                actionName = IndexAction;
            }
            else
            {
                controllerName = pathArgs[0].Capitalize() + Controller;
                actionName = pathArgs[1].Capitalize();
            }

            // Getting Controller
            Controller controller = this.GetController(controllerName, request);
            if (controller == null) return new HttpResponse(HttpResponseStatusCode.NotFound);

            // Getting Method
            MethodInfo action = this.GetMethod(requestMethod, controller, actionName);
            if (action == null) return new HttpResponse(HttpResponseStatusCode.NotFound);

            object[] actionParameters = this.MapActionParameters(controller, action, request);

            IActionResult actionResult = this.InvokeAction(controller, action, actionParameters);
            
            return this.PrepareResponse(actionResult);
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if(controllerName != null)
            {
                string controllerTypeName
                    = string.Format(
                        "{0}.{1}.{2}, {0}",
                        MvcContext.Get.AssemblyName,
                        MvcContext.Get.ControllersFolder,
                        controllerName);
                
                Type controllerType = Type.GetType(controllerTypeName);
                Controller controller = Activator.CreateInstance(controllerType) as Controller;

                if (controller != null) controller.Request = request;

                return controller;
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach(MethodInfo methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                IEnumerable<HttpMethodAttribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(attr => attr is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper() == "GET") return methodInfo;

                foreach(HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod)) return methodInfo;
                }
            }

            return method;
        }
        
        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null) return new MethodInfo[0];

            return controller
                .GetType()
                .GetMethods()
                .Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable) return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);

            if (actionResult is IRedirectable) return new RedirectResult(invocationResult);

            throw new InvalidOperationException("This action is not supported.");
        }

        private object[] MapActionParameters(Controller controller, MethodInfo action, IHttpRequest request)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for(int index = 0; index < actionParametersInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParametersInfo[index];

                if(currentParameterInfo.ParameterType.IsPrimitive || currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[index] = this.ProcessPrimitiveParameter(currentParameterInfo, request);
                }
                else
                {
                    object bindingModel = this.ProcessBindingModelParameters(currentParameterInfo, request);

                    controller.ModelState.IsValid = this.IsValidModel(bindingModel);

                    mappedActionParameters[index] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
            => action.Invoke(controller, actionParameters) as IActionResult;

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest request)
        {
            object value = this.GetParameterFromRequestData(request, param.Name);

            return Convert.ChangeType(value, param.ParameterType);
        }

        private object ProcessBindingModelParameters(ParameterInfo param, IHttpRequest request)
        {
            Type bindingModelType = param.ParameterType;

            object bindingModelInstace = Activator.CreateInstance(bindingModelType);
            PropertyInfo[] bindingModelProperties = bindingModelType.GetProperties();
            
            foreach(PropertyInfo property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(request, property.Name);

                    property.SetValue(bindingModelInstace, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstace, bindingModelType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string paramName)
        {
            if (request.QueryData.ContainsKey(paramName)) return request.QueryData[paramName];
            if (request.FormData.ContainsKey(paramName)) return request.FormData[paramName];

            return null;
        }

        private bool IsValidModel(object bindingModel)
        {
            Type bindingModelType = bindingModel.GetType();

            PropertyInfo[] properties = bindingModelType.GetProperties();

            foreach(PropertyInfo property in properties)
            {
                ValidationAttribute[] propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToArray();

                foreach(ValidationAttribute validationAttribute in propertyValidationAttributes)
                {
                    if (!validationAttribute.IsValid(property.GetValue(bindingModel))) return false;
                }
            }

            return true;
        }
    }
}
