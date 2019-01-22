using SIS.HTTP.Enums;
using SIS.WebServer.Routing;

namespace SIS.Demo
{
    class Launcher
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
