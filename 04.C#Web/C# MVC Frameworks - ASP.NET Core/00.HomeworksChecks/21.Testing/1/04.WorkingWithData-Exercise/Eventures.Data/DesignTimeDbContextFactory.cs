using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Eventures.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventuresDbContext>
    {
        public EventuresDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"C:\Users\Tsvetan Atanasov\Documents\Visual Studio 2017\Projects\ASP.NET Core Projects\04.WorkingWithData-Exercise\Eventures.App\appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<EventuresDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new EventuresDbContext(builder.Options);
        }
    }
}
