namespace EventuresWebApp.Web.Middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var signInManager = provider.GetService<SignInManager<EventuresUser>>();
            if (!signInManager.UserManager.Users.Any())
            {
                var roleManager = provider.GetService<RoleManager<IdentityRole>>();
                var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;
                if (!adminRoleExists)
                {
                    var result = roleManager.CreateAsync(new IdentityRole("Administrator")).Result;
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException();
                    }
                }

                var user = new EventuresUser
                {
                    Email = "admin@admin.com",
                    UserName = "Admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    UniqueCitizenNumber = "admin12456677"
                };

                var signResult = signInManager.UserManager.CreateAsync(user, "12345678").Result;
                var roleResult = signInManager.UserManager.AddToRoleAsync(user, "Administrator").Result;
            }

            await this.next(context);
        }
    }
}
