using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVENTURES.App.Utilities
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator")).GetAwaiter();
                //roleManager.SetRoleNameAsync(new IdentityRole(), "Administrator");
            }
        }
    }
}
