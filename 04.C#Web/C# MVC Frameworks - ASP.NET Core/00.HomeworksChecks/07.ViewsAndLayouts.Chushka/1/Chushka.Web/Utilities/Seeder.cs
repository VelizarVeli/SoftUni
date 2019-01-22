using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Chushka.Web.Utilities
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            string[] roles =
            {
                RoleNames.Administrator,
                RoleNames.User
            };

            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                var roleExists = roleManager.RoleExistsAsync(role).Result;

                if (!roleExists)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }
        }
    }
}
