using Google.Data;
using Microsoft.EntityFrameworkCore;

namespace Google.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly GoogleContext context;

        public DbInitializerService(GoogleContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
