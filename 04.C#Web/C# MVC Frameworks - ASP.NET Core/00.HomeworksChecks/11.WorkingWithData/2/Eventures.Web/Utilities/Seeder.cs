using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.Extensions.DependencyInjection;
namespace Eventures.Web.Utilities
{
    public class Seeder 
    {
        public static void Seed (IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            var userRoleExists = roleManager.RoleExistsAsync("User").Result;
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
