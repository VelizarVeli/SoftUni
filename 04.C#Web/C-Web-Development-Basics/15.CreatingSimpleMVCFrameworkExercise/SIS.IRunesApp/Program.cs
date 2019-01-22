namespace SIS.IRunesApp
{
    using HTTP.Enums;
    using IRunesApp.Controllers;
    using WebServer;
    using WebServer.Results;
    using WebServer.Routing;

    public class Program
    {
        public static void Main(string[] args)
        {
           // ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
           // // Home
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new /HomeController/().Index(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Home/Index"] = request => new //RedirectResult("/");
           // // User
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Login"] = request => new //UsersController().Login(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Register"] = request => /new /UsersController().Register(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Login"] = request => new //UsersController().DoLogin(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Post]["/Users/Register"] = request => /new /UsersController().DoRegister(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Logout"] = request => new //UsersController().Logout(request);
           // //Album
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/All"] = request => new //AlbumsController().All(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Create"] = request => new //AlbumsController().Create(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Post]["/Albums/Create"] = request => /new /AlbumsController().DoCreate(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Albums/Details"] = request => /new /AlbumsController().Details(request);
           //
           // //Track
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Tracks/Create"] = request => new //TracksController().Create(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Post]["/Tracks/Create"] = request => /new /TracksController().DoCreate(request);
           // serverRoutingTable.Routes[HttpRequestMethod.Get]["/Tracks/Details"] = request => /new /TracksController().Details(request);
           //
           // WebServer server = new WebServer(8000, serverRoutingTable);
           // server.Run();
        }
    }
}
