using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        private string[] Roles = { "Admin", "User" };

        private const string AdminUsername = "admin";

        private const string AdminPassword = "12345";

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next; 
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

            this.SeedRoles(roleManager);

            var db = provider.GetService<EventuresDbContext>();
            var userManager = provider.GetService<UserManager<EventuresUser>>();

            this.SeedFirstUser(db, userManager);

            await this.next(context);
        }

        private void SeedFirstUser(EventuresDbContext db, UserManager<EventuresUser> userManager)
        {
            if(!db.Users.Any())
            {
                EventuresUser admin = new EventuresUser
                {
                    UserName = AdminUsername,
                    Email = "admin@admin.com",
                    FirstName = "Oniq",
                    LastName = "Loshiq",
                    UCN = "1818181818"
                };

                var result = userManager.CreateAsync(admin, AdminPassword).Result;

                if (result.Succeeded)
                {
                    var roleResult = userManager.AddToRoleAsync(admin, "Admin").Result;
                }
            }
        }

        private void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var roleName in Roles)
            {
                Task<bool> roleExist = roleManager.RoleExistsAsync(roleName);
                roleExist.Wait();

                if (!roleExist.Result)
                {
                    Task<IdentityResult> roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
                    roleResult.Wait();
                }
            }
        }
    }
}
