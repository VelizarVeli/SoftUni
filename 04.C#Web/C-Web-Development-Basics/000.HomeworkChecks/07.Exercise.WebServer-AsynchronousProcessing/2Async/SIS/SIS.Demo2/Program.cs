using System;
using SIS.Http.Enum;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace SIS.Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routs[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}