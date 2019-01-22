using SIS.MvcFramework;

namespace MishMashWebApp
{
    class Program
    {
        static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
