namespace EventWebApp.Middlewares
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Internal;

    public class SeedUserRolesAndAdminMiddleware
    {
        private readonly RequestDelegate next;

        public SeedUserRolesAndAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext dbContext,IServiceProvider serviceProvider)
        {
            if (!dbContext.Users.Any())
            {
                ApplicationDbContextSeeder.Seed(dbContext, serviceProvider);
            }
           
            await this.next(httpContext);
        }
    }
}

