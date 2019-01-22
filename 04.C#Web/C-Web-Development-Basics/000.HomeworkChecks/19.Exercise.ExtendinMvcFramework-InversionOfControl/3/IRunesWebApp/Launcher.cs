using System;
using System.Collections.Generic;
using IRunesWebApp.Controllers;
using IRunesWebApp.Services;
using Services;
using SIS.Framework;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;

namespace IRunesWebApp
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var dependencyMap = new Dictionary<Type, Type>();
            var dependencyContainer = new DependencyContainer(dependencyMap);
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUsersService, UsersService>();

            var handlingContext = new HttpRouteHandlingContext(
                new ControllerRouter(dependencyContainer),
                new ResourceRouter());
            Server server = new Server(80, handlingContext);
            var engine = new MvcEngine();
            engine.Run(server);
        }
    }
}
