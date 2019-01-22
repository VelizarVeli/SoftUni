namespace WebServer.IRunesApplication
{

    using IRunesApplication.Controllers;
    using IRunesApplication.Data;
    using Microsoft.EntityFrameworkCore;
    using Server.Contracts;
    using Server.Routing.Contracts;
    using ViewModels.Account;
    using ViewModels.Product;

    public class IRunesApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new IRunesDbContext())
            {
                db.Database.Migrate();
            }
        }
        public void Configure(IAppRouteConfig routeConfig)
        {
            routeConfig.AnonymousPaths.Add("/");
            routeConfig.AnonymousPaths.Add("/Home/Index");
            routeConfig.AnonymousPaths.Add("/Users/Login");
            routeConfig.AnonymousPaths.Add("/Users/Register");
            
            routeConfig.Get("/", 
                req => new HomeController(req)
                .Index());

            routeConfig.Get("/Home/IndexLogged",
                req => new HomeController(req)
                .IndexLogged());

            routeConfig.Get("/Users/Login",
                req => new AccountController(req)
                .Login());

            routeConfig.Post("/Users/Login",
                req => new AccountController(req)
                .Login(new LoginViewModel()
                {
                    Username = req.FormData["name"],
                    Passsword = req.FormData["password"]
                }));

            routeConfig.Get("/Users/Register",
                req => new AccountController(req)
                .Register());

            routeConfig.Post("/Users/Register",
                req => new AccountController(req).
                Register(new RegisterUserViewModel()
                {
                    Username = req.FormData["username"],
                    Password = req.FormData["password"],
                    ConfirmPassword = req.FormData["confirm-password"],
                    Email = req.FormData["email"]
                }));

            routeConfig.Get("/Albums/All",
                req => new AlbumController(req)
                .All());

            routeConfig.Get("/Albums/Create",
                req => new AlbumController(req).Add());

            routeConfig.Post("/Albums/Create",
                req => new AlbumController(req).Add(new AddProductViewModel()
                {
                    Name = req.FormData["name"],
                    Url =req.FormData["picture-url"]
                }));

            routeConfig.Get("/Albums/Details/{(?<id>[0-9]+)}",
                req => new AlbumController(req)
                .Details(int.Parse(req.UrlParameters["id"])));

            routeConfig.Get("/Track/Create/{(?<id>[0-9]+)}",
                req => new TrackController(req)
                .Create(int.Parse(req.UrlParameters["id"])));

            routeConfig.Post("/Track/Create/{(?<id>[0-9]+)}",
                req => new TrackController(req)
                .Create(new AddTrackViewModel()
                {
                    Name = req.FormData["name"],
                    Link = req.FormData["link"],
                    Price = decimal.Parse(req.FormData["price"])
                },
                int.Parse(req.UrlParameters["id"])));

            routeConfig.Get("/Tracks/Details/{(?<albumId>[0-9]+)}/{(?<trackId>[0-9]+)}",
                req => new TrackController(req)
                .Details(int.Parse(req.UrlParameters["albumId"]),
                         int.Parse(req.UrlParameters["trackId"])));
            
            routeConfig.Get("/logout",
                req => new AccountController(req)
                .Logout());            
        }
    }
}
