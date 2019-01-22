namespace EventWebApp.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            Seed(dbContext, roleManager, userManager);
        }

        public static void Seed(ApplicationDbContext dbContext, RoleManager<ApplicationRole> roleManager,
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

            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            SeedRoles(roleManager);
            SeedAdminUser(userManager).GetAwaiter().GetResult();
        }

        private static async Task SeedAdminUser(UserManager<ApplicationUser> userManager)
        {
            var users = userManager.Users.ToList();

            ApplicationUser admin = await userManager.FindByNameAsync("Admin");

            if (admin == null)
            {
                admin = new ApplicationUser()
                {
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Adminof"
                };
                await userManager.CreateAsync(admin, "123456");
                await userManager.AddToRoleAsync(admin, "Admin");
                
            }
        }

        private static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            foreach (var roleName in GlobalConstants.RolesName)
            {
                SeedRole(roleName, roleManager);
            }
        }

        private static void SeedRole(string roleName, RoleManager<ApplicationRole> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
            if (role == null)
            {
                var result = roleManager.CreateAsync(new ApplicationRole(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
