using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Panda.Web.Areas.Identity.IdentityHostingStartup))]
namespace Panda.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}