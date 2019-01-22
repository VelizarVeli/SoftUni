using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes;
using SIS.Framework.Common;
using SIS.Framework.Controllers;
using SIS.Framework.Controllers.Contracts;
using SIS.HTTP.Enumerations;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.HTTP.Responses.Contracts;
using SIS.Services.Contracts;
using SIS.WebServer.Routing.Contracts;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IControllerRouter
    {
	private readonly IServiceCollection services;
	private ITextService TextService => services.GetService<ITextService>();

	public ControllerRouter(IServiceCollection services)
	{
	    this.services = services;
	}

	public IHttpResponse Handle(IHttpRequest request)
	{
	    string[] requestPathComponents = request.Path
		.Split('/', StringSplitOptions.RemoveEmptyEntries);
	    string controllerName = Constants.DefaultControllerName;
	    string actionName = Constants.DefaultActionName;
	    if (requestPathComponents.Length == 2)
	    {
		controllerName = TextService.ToTitleCase(requestPathComponents[0]);
		actionName = TextService.ToTitleCase(requestPathComponents[1]);
	    }
	    IController controller = GetController(controllerName);
	    if (controller == null)
	    {
		return PrepareResponse(new NotFoundResult(
		    typeof(Controller).Name, controllerName));
	    }
	    controller.Request = request;
	    MethodInfo action = GetAction(request.Method, controller, actionName);
	    if (action == null)
	    {
		return new NotFoundResponse(string.Format(Constants.NotFoundResultMessage,
		    "Action", $"[{request.Method}]{controllerName}/{actionName}"));
	    }
	    if (!IsAuthenticated(controller, action))
	    {
		return new UnauthenticatedResponse();
	    }
	    if (!IsAuthorized(controller, action))
	    {
		return new UnauthorizedResponse();
	    }
	    ParameterInfo[] actionParameters = action.GetParameters();
	    object[] mappedActionParameters = MapActionParameters(controller, actionParameters, request);
	    IActionResult actionResult = (IActionResult)action.Invoke(controller, mappedActionParameters);
	    IHttpResponse response = PrepareResponse(actionResult);
	    return response;
	}

	private IController GetController(string controllerName)
	{
	    Type controllerType = Assembly.GetEntryAssembly().GetTypes()
		.SingleOrDefault(t => t.BaseType == typeof(Controller)
		&& t.Name.StartsWith(controllerName));
	    IController controller = (IController)services.GetService(controllerType);
	    return controller;
	}

	private MethodInfo GetAction(HttpRequestMethod requestMethod, IController controller, string actionName)
	{
	    var suitableActions = GetSuitableActions(controller, actionName);
	    if (!suitableActions.Any()) return null;
	    foreach (var suitableAction in suitableActions)
	    {
		var httpMethodAttributes = suitableAction
		    .GetCustomAttributes<HttpMethodAttribute>();
		foreach (var httpMethodAttribute in httpMethodAttributes)
		{
		    if (httpMethodAttribute.IsValid(requestMethod))
		    {
			return suitableAction;
		    }
		}
	    }
	    return null;
	}

	private IEnumerable<MethodInfo> GetSuitableActions(IController controller, string actionName)
	{
	    var suitableActions = controller.GetType().GetMethods()
		.Where(m => m.Name.ToUpper() == actionName.ToUpper());
	    return suitableActions;
	}

	private bool IsAuthenticated(IController controller, MethodInfo action)
	{
	    var actionAuthentication = action.GetCustomAttribute<AuthenticateAttribute>();
	    if (actionAuthentication != null)
	    {
		return actionAuthentication.IsAuthenticated(controller.Identity);
	    }
	    return true;
	}

	private bool IsAuthorized(IController controller, MethodInfo action)
	{
	    var actionAuthorization = action.GetCustomAttribute<AuthorizeAttribute>();
	    if (actionAuthorization != null)
	    {
		return actionAuthorization.IsAuthorized(controller.Identity);
	    }
	    return true;
	}

	private object[] MapActionParameters(IController controller, ParameterInfo[] actionParameters, IHttpRequest request)
	{
	    if (!actionParameters.Any()) return null;
	    object[] mappedActionParameters = new object[actionParameters.Length];
	    for (int p = 0; p < actionParameters.Length; p++)
	    {
		ParameterInfo currentParameter = actionParameters[p];
		if (currentParameter.ParameterType.IsPrimitive
		    || currentParameter.ParameterType == typeof(string))
		{
		    mappedActionParameters[p] = ProcessPrimitiveActionParameter(currentParameter, request);
		}
		else
		{
		    object bindingModel = ProcessBindingModelParameter(currentParameter, request);
		    controller.ModelState.IsValid = IsValidModel(bindingModel);
		    mappedActionParameters[p] = bindingModel;
		}
	    }
	    return mappedActionParameters;
	}

	private object ProcessPrimitiveActionParameter(ParameterInfo parameter, IHttpRequest request)
	{
	    object parameterValue = GetParameterFromRequestData(parameter.Name, request);
	    return Convert.ChangeType(parameterValue, parameter.ParameterType);
	}

	private object ProcessBindingModelParameter(ParameterInfo parameter, IHttpRequest request)
	{
	    Type bindingModelType = parameter.ParameterType;
	    var bindingModelInstance = Activator.CreateInstance(bindingModelType);

	    var bindingModelProperties = bindingModelType.GetProperties();
	    foreach (var property in bindingModelProperties)
	    {
		try
		{
		    object value = GetParameterFromRequestData(property.Name, request);
		    if (value != null)
		    {
			var propertyValue = Convert.ChangeType(value, property.PropertyType);
			property.SetValue(bindingModelInstance, propertyValue);
		    }
		}
		catch
		{
		    Console.WriteLine($"Property {property.Name} could not be mapped.");
		}
	    }
	    return bindingModelInstance;
	}

	private object GetParameterFromRequestData(string parameterName, IHttpRequest request)
	{
	    object parameterValue = null;
	    if (request.QueryData.ContainsKey(parameterName))
	    {
		parameterValue = request.QueryData[parameterName];
	    }
	    if (request.FormData.ContainsKey(parameterName))
	    {
		parameterValue = request.FormData[parameterName];
	    }
	    return parameterValue;
	}

	private bool IsValidModel(object model)
	{
	    PropertyInfo[] modelProperties = model.GetType().GetProperties();
	    foreach (var property in modelProperties)
	    {
		var propertyValidationAttributes = property
		    .GetCustomAttributes<ValidationAttribute>();
		foreach (var validationAttribute in propertyValidationAttributes)
		{
		    var propertyValue = property.GetValue(model);
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
	    if (actionResult is IViewResult)
	    {
		string content = actionResult.Invoke();
		return new HtmlResponse(content);
	    }
	    else if (actionResult is IRedirectResult)
	    {
		string location = actionResult.Invoke();
		return new RedirectResponse(location);
	    }
	    else if (actionResult is IUnauthorizedResult)
	    {
		string content = actionResult.Invoke();
		return new UnauthenticatedResponse(content);
	    }
	    else if (actionResult is IBadRequestResult)
	    {
		string message = actionResult.Invoke();
		return new BadRequestResponse(message);
	    }
	    else if (actionResult is INotFoundResult)
	    {
		string message = actionResult.Invoke();
		return new NotFoundResponse(message);
	    }
	    else
	    {
		return new InternalServerErrorResponse();
	    }
	}
    }
}
