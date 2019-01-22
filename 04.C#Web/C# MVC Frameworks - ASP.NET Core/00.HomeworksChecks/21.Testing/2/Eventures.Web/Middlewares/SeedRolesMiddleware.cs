using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Eventures.Web.Middlewares
{
    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate next;
        private const string Administrator = "Administrator";
    
        public SeedRolesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            UserManager<EventureUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await SeedRoles(userManager, roleManager);
            }

            // Call the next delegate/middleware in the pipeline
            await next(context);
        }

        private async Task SeedRoles(
            UserManager<EventureUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = Administrator
            });

            var user = new EventureUser
            {
                UserName = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                Ucn = "9999999999",
            };
            
            await userManager.CreateAsync(user, "admin");

            await userManager.AddToRoleAsync(user, Administrator);
        }
    }
}

