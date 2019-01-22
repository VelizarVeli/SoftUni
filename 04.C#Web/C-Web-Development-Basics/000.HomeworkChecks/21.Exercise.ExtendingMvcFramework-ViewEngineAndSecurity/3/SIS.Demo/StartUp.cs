using IRunes.Services;
using SIS.Framework;
using SIS.Framework.Routes;
using SIS.Framework.Services;
using SIS.Framework.Services.Contracts;
using SIS.WebServer;
using System;
using System.Collections.Generic;

namespace SIS.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dependencyMap = new Dictionary<Type, Type>();
            var dependencyContainer = new DependencyContainer(dependencyMap);
            dependencyContainer.RegisterDependency<IHashService, HashService>();

            var handlingContext = new HttpRouteHandlingContext(new ControllerRouter(dependencyContainer), new ResourceRouter());
            Server server = new Server(80, handlingContext);

            MvcEngine.Run(server);
        }
    }
}