namespace IRunesApp
{
    using SIS.Framework;
    using SIS.Framework.Routers;
    using SIS.Framework.Services;
    using SIS.Framework.Services.Contracts;
    using SIS.WebServer;

    public class Launcher
    {
        public static void Main()
        {
            var container = new DependencyContainer();
            container.RegisterDependency<IHashService, HashService>();
            container.RegisterDependency<IUserService, UserService>();

            var handlingContext = new HttpRouteHandler(new ControllerRouter(container), new ResourceRouter());
            var server = new Server(80, handlingContext);
            MvcEngine.Run(server);
        }

        //private static void ConfigureRouting(ServerRoutingTable serverRoutingTable)
        //{
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/index"] = request => new RedirectResult("/");
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController { Request = request }.Index();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/login"] = request => new UsersController { Request = request }.Login();
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/login"] = request => new UsersController { Request = request }.DoLogin();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/register"] = request => new UsersController { Request = request }.Register();
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/register"] = request => new UsersController { Request = request }.DoRegister();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/all"] = request => new AlbumsController { Request = request }.All();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/create"] = request => new AlbumsController { Request = request }.Create();
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/albums/create"] = request => new AlbumsController { Request = request }.DoCreate();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/details"] = request => new AlbumsController { Request = request }.Details();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/tracks/create"] = request => new TracksController { Request = request }.Create();
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/tracks/create"] = request => new TracksController { Request = request }.DoCreate();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/tracks/details"] = request => new TracksController { Request = request }.Details();

        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/logout"] = request => new UsersController { Request = request }.Logout();
        //}
    }
}