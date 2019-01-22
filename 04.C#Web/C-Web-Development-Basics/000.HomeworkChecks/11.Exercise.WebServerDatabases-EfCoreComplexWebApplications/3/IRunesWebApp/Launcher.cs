using IRunesWebApp.Data;

namespace IRunesWebApp
{
    using SIS.WebServer.Routing;
    using System;
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using IRunesWebApp.Controllers;
    using SIS.WebServer.Results;

    public class Launcher
    {
        static void Main(string[] args)
        {
            using (IRunnesContext context = new IRunnesContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/index"] = request => new RedirectResult("/");
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/login"] = request => new UsersController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/register"] = request => new UsersController().Register(request);

            //POST
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/login"] = request => new UsersController().PostLogin(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/register"] = request => new UsersController().PostRegister(request);
            Server server = new Server(80, serverRoutingTable);

            server.Run();
        }
    }
}
