using System;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace SIS.Demo
{
    public class Launcher
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();

            // My routes for test
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] = request => new AccountController().Login();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/login"] = request => new AccountController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] = request => new AccountController().Register();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] = request => new AccountController().Register(request);
            // End of My routes for test

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
