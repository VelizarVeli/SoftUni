namespace SIS.Demo
{
    using Framework;
    using Framework.Routers;
    using Framework.Services;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            var handler = new ControllerRouter(new DependencyContainer());

            var server = new Server(80, handler);
            MvcEngine.Run(server);
        }
    }
}