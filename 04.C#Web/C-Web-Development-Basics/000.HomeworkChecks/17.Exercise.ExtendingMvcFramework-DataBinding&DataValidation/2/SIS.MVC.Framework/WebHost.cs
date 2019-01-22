namespace SIS.MVC.Framework
{
    using Application.Contracts;
    using Attributes;
    using Controllers;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using Services;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using WebServer;
    using WebServer.Routing;

    public static class WebHost
    {
        public static void Start(IMvcApplication application)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            var collection = new ServiceCollection();
            application.ConfigureServices(collection);

            var routingTable = new ServerRoutingTable();
            ConfigureRouting(routingTable, collection);

            var server = new Server(80, routingTable);
            server.Run();
        }

        private static void ConfigureRouting(ServerRoutingTable routingTable, IServiceCollection collection)
        {
            var controllers = Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Controller)));

            foreach (var controller in controllers)
            {
                var methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m =>
                    m.CustomAttributes.Any(a => a.AttributeType.IsSubclassOf(typeof(HttpAttribute))));
                foreach (var methodInfo in methods)
                {
                    var httpAttribute = (HttpAttribute)methodInfo.GetCustomAttributes()
                        .FirstOrDefault(a => a.GetType().IsSubclassOf(typeof(HttpAttribute)));

                    if (httpAttribute == null)
                    {
                        continue;
                    }

                    routingTable.Add(httpAttribute.Method, httpAttribute.Path,
                        request => ExecuteAction(controller, methodInfo, request, collection));
                }
            }
        }

        private static IHttpResponse ExecuteAction(Type controllerType, MethodInfo action, IHttpRequest request, IServiceCollection collection)
        {
            var controller = (Controller)collection.CreateInstance(controllerType);
            controller.Request = request;
            controller.UserCookieService = collection.CreateInstance<IUserCookieService>();

            var actionParamsList = GetActionParamObjects(action, request, collection);

            return (IHttpResponse)action.Invoke(controller, actionParamsList.ToArray());
        }

        private static List<object> GetActionParamObjects(MethodInfo action, IHttpRequest request, IServiceCollection collection)
        {
            var actionParamsList = new List<object>();
            foreach (var paramInfo in action.GetParameters())
            {
                if (paramInfo.ParameterType.IsValueType || Type.GetTypeCode(paramInfo.ParameterType) == TypeCode.String)
                {
                    var stringValue = GetRequestData(request, paramInfo.Name);
                    actionParamsList.Add(TryParseValue(stringValue, paramInfo.ParameterType));
                }
                else
                {
                    var actionParam = collection.CreateInstance(paramInfo.ParameterType);
                    actionParamsList.Add(actionParam);

                    var properties = paramInfo.ParameterType.GetProperties();
                    foreach (var propInfo in properties)
                    {
                        string stringValue = GetRequestData(request, propInfo.Name);

                        object value = TryParseValue(stringValue, propInfo.PropertyType);

                        propInfo.SetMethod.Invoke(actionParam, new object[] { value });
                    }
                }
            }

            return actionParamsList;
        }

        private static string GetRequestData(IHttpRequest request, string propName)
        {
            propName = propName.ToLower();
            string stringValue = string.Empty;
            if (request.FormData.Any(a => a.Key.ToLower() == propName))
            {
                stringValue = WebUtility.UrlDecode(request.FormData.First(a => a.Key.ToLower() == propName).Value.ToString());
            }
            else if (request.QueryData.Any(a => a.Key.ToLower() == propName))
            {
                stringValue = WebUtility.UrlDecode(request.QueryData.First(a => a.Key.ToLower() == propName).Value.ToString());
            }

            return stringValue;
        }

        private static object TryParseValue(string stringValue, Type type)
        {
            var typeCode = Type.GetTypeCode(type);
            object value = null;
            switch (typeCode)
            {
                case TypeCode.Int32:
                    if (int.TryParse(stringValue, out var intValue))
                    {
                        value = intValue;
                    }
                    break;

                case TypeCode.Char:
                    if (char.TryParse(stringValue, out char charValue))
                    {
                        value = charValue;
                    }
                    break;

                case TypeCode.Int64:
                    if (long.TryParse(stringValue, out var longValue))
                    {
                        value = longValue;
                    }
                    break;

                case TypeCode.Double:
                    if (double.TryParse(stringValue, out var doublValue))
                    {
                        value = doublValue;
                    }
                    break;

                case TypeCode.Decimal:
                    if (decimal.TryParse(stringValue, out var decimalValue))
                    {
                        value = decimalValue;
                    }
                    break;

                case TypeCode.DateTime:
                    if (DateTime.TryParse(stringValue, out var dateTimeValue))
                    {
                        value = dateTimeValue;
                    }
                    break;

                case TypeCode.String:
                    value = stringValue;
                    break;
            }

            return value;
        }
    }
}