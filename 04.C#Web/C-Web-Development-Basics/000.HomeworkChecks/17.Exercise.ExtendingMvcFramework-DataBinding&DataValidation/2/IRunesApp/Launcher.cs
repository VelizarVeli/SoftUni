namespace IRunesApp
{
    using SIS.MVC.Framework;
    using SIS.MVC.Framework.Application;

    public class Launcher
    {
        public static void Main()
        {
            var application = new MvcApplication();
            WebHost.Start(application);
        }
    }
}