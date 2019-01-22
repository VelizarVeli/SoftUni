using SIS.MvcFramework;

namespace TORSHIAWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
