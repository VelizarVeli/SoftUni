using IRunes.Services;
using IRunes.Services.Contracts;
using SIS.Framework;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.WebServer;
using System;
using System.Collections.Generic;

namespace IRunes.App
{
    public class Launcher
    {
        public static void Main()
        {
            DependencyContainer dependencyContainer = RegisterDependencies();

            var server = new Server(1337, new ControllerRouter(dependencyContainer));
            MvcEngine.Run(server);
        }

        public  static DependencyContainer RegisterDependencies()
        {
            var dependencyMap = new Dictionary<Type, Type>();
            var dependencyContainer = new DependencyContainer(dependencyMap);
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IAlbumService, AlbumService>();
            dependencyContainer.RegisterDependency<ITrackService, TrackService>();
            dependencyContainer.RegisterDependency<IUserService, UserService>();
            return dependencyContainer;
        }

    }

}
