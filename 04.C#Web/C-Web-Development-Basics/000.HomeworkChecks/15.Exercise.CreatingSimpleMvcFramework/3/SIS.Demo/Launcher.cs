using SIS.Framework;
using SIS.Framework.Routers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Api;
using SIS.WebServer.Routing;
using System;

namespace SIS.Demo
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Server server = new Server(8808, new ControllerRouter());

            MvcEngine.Run(server);
        }
    }
}
