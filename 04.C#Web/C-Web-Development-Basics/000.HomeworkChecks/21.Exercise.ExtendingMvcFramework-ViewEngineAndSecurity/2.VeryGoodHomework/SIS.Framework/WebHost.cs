using SIS.Framework.Api.Contracts;
using SIS.Framework.Common;
using SIS.Framework.Routers;
using SIS.HTTP.Sessions;
using SIS.HTTP.Sessions.Contracts;
using SIS.Services;
using SIS.Services.Contracts;
using SIS.WebServer;
using SIS.WebServer.Contracts;
using SIS.WebServer.Routing.Contracts;

namespace SIS.Framework
{
    public static class WebHost
    {
	public static void Start(IMvcApplication application)
	{
	    IServiceCollection services = InitializeServices();
	    application.ConfigureServices(services);
	    application.Configure();
	    Server server = new Server(Constants.ServerHostPort, services);
	    MvcEngine engine = new MvcEngine(server);
	    engine.Run();
	}

	private static IServiceCollection InitializeServices()
	{
	    IServiceCollection services = new ServiceCollection();
	    services.RegisterService<IHttpSessionStorage, HttpSessionStorage>();
	    services.RegisterService<IConnectionHandler, ConnectionHandler>();
	    services.RegisterService<IControllerRouter, ControllerRouter>();
	    services.RegisterService<IResourceRouter, ResourceRouter>();
	    services.RegisterService<IEnumerationService, EnumerationService>();
	    services.RegisterService<IEncryptionService, EncryptionService>();
	    services.RegisterService<ITextService, TextService>();
	    return services;
	}
    }
}
