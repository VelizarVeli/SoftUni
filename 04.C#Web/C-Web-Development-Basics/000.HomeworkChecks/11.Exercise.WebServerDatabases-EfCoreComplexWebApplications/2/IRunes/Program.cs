using IRunes.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;
using System;
using IRunes.Data;

namespace IRunes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IRunesDbContext context = new IRunesDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            // {controller}/{action}/{id}
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Home/Index"] = request => new HomeController().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Login"] = request => new AccountController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Login"] = request => new AccountController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Register"] = request => new AccountController().Register();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Register"] = request => new AccountController().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/All"] = request => new AlbumController().All();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Create"] = request => new AlbumController().Create();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Albums/Create"] = request => new AlbumController().Create(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Details?id={albumId}"] = request => new AlbumController().Details(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Tracks/Create?albumId={albumId}"] = request => new TrackController().Create();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/Tracks/Create?albumId={albumId}"] = request => new TrackController().Create(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Tracks/Details?albumId={albumId}&trackId={trackId}"] = request => new TrackController().Details(request);


            Server server = new Server(8080, serverRoutingTable);

            server.Run();
        }
    }
}
