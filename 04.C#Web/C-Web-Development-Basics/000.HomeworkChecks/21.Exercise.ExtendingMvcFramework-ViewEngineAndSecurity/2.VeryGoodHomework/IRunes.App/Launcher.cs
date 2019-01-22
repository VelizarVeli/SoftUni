using IRunes.Data;
using SIS.Framework;

namespace IRunes.App
{
    public class Launcher
    {
	public static void Main()
	{
	    using (IRunesDbContext context = new IRunesDbContext())
	    {
	        context.Database.EnsureDeleted();
	        context.Database.EnsureCreated();
	    }

	    WebHost.Start(new Startup());
	}
    }
}
