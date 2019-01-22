namespace SIS.Demo
{
    using Framework;
    using Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            Server server = new Server(8000, new HttpHandlersContext(new ControllerRouter(), new ResourceRouter()));

            MvcEngine.Run(server);
        }
    }
}
