using IRunes.App.Controllers;
using IRunes.App.Controllers.Contracts;
using IRunes.Data;
using IRunes.Services;
using IRunes.Services.Contracts;
using SIS.Framework.Api;
using SIS.Services.Contracts;

namespace IRunes.App
{
    public class Startup : MvcApplication
    {
	public override void ConfigureServices(IServiceCollection services)
	{
	    services.RegisterDbContext<IRunesDbContext>();
	    services.RegisterService<IHomeController, HomeController>();
	    services.RegisterService<IUserService, UserService>();
	    services.RegisterService<IUsersController, UsersController>();
	    services.RegisterService<IAlbumService, AlbumService>();
	    services.RegisterService<IAlbumsController, AlbumsController>();
	    services.RegisterService<IAlbumTrackService, AlbumTrackService>();
	    services.RegisterService<ITrackService, TrackService>();
	    services.RegisterService<ITracksController, TracksController>();
	}
    }
}
