using System;
using SIS.Framework;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;
using SIS.Framework.Routers;
namespace SIS.Demo
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var server = new Server(80, new ControllerRouter(), new ResourceRouter());
            
            MvcEngine.Run(server);
            
        }
    }
}
