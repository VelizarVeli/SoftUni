using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Web.CustomMiddlewares
{
    public class DatabaseSeeder
    {
        private readonly RequestDelegate next;

        public DatabaseSeeder(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, 
                                      EventuresDbContext dbContext,
                                      RoleManager<IdentityRole> roleManager,
                                      UserManager<ApplicationUser> userManager)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            dbContext.Database.Migrate();

            SeedRoles(roleManager);
            SeedUsers(userManager);

            await this.next(context);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            SeedRole("Admin", roleManager);
            SeedRole("User", roleManager);
        }
        private static void SeedRole(string roleName, RoleManager<IdentityRole> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();

            if (role != null) return;

            var result = roleManager
                .CreateAsync(new IdentityRole() { Name = roleName, NormalizedName = roleName.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() }).GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }
        }
        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser()
            {
                UserName = "Georgi123",
                FirstName = "Georgi",
                LastName = "Georgiev",
                UCN = "abcdefg"
            };

            var user = new ApplicationUser()
            {
                UserName = "Pesho123",
                FirstName = "Petar",
                LastName = "Petrov",
                UCN = "abcdefghijkl"
            };

            var adminResult = userManager.CreateAsync(admin, "admin123").Result;
            var userResult = userManager.CreateAsync(user, "user123").Result;

            if (adminResult.Succeeded)
            {
                userManager.AddToRoleAsync(admin, "Admin")
                    .GetAwaiter().GetResult();
            }

            if (userResult.Succeeded)
            {
                userManager.AddToRoleAsync(user, "User")
                    .GetAwaiter().GetResult();
            }
        }
    }
}
