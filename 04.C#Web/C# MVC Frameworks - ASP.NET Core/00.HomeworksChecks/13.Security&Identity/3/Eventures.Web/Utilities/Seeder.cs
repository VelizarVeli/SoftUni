using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Utilities
{
    public class Seeder
    {
        public static void SeedRoles(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }

            var userRoleExists = roleManager.RoleExistsAsync("User").Result;
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).Wait();
            }
        }
    }
}
