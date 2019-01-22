using SIS.MvcFramework;

namespace MusakaWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
