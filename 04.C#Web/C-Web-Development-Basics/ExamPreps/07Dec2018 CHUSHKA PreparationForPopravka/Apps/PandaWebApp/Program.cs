using SIS.MvcFramework;

namespace ChushkaWebApp
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
