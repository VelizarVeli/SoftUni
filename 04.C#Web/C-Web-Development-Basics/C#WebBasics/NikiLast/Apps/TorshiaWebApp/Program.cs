using SIS.MvcFramework;

namespace TorshiaWebApp
{
  public  class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
