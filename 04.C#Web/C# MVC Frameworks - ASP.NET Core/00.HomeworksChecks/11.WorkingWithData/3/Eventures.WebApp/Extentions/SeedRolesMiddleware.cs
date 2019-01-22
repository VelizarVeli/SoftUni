namespace Eventures.WebApp.Extentions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedRolesMiddleware(RequestDelegate next)
        {
            _next = next;
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
            await _next(context);
        }

        private async Task SeedRoles(
            UserManager<EventureUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "admin"
            });

            var user = new EventureUser
            {
                UserName = "AppAdmin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                UniqueCitizenNumber = "1111111"
            };
            await userManager.CreateAsync(user, "admin");

            await userManager.AddToRoleAsync(user, "admin");
        }
    }
}