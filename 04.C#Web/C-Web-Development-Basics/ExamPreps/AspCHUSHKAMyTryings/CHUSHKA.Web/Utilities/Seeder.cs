using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CHUSHKA.Web.Utilities
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;

            var adminRole = roleManager.Roles.FirstOrDefault(r => r.Name == "Administrator");

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
        }
    }
}
