using WebServer.IRunesApplication.Data;

namespace WebServer
{
    using WebServer.Server.Contracts;
    using WebServer.Server;
    using WebServer.Server.Routing.Contracts;
    using WebServer.Server.Routing;
    using WebServer.IRunesApplication;

    public class Launcher : IRunnable
    {
        private WebServer webServer;

        public static void Main()
        {
            //using (IRunesDbContext context = new IRunesDbContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //}

            new Launcher().Run();
        }
        public void Run()
        {
            IApplication app = new IRunesApp();

            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Configure(routeConfig);

            this.webServer = new WebServer(8230, routeConfig);
            this.webServer.Run();
        }
    }
}
