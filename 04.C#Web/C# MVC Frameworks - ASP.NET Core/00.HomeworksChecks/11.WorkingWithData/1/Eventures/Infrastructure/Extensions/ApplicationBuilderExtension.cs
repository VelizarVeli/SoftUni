using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();

                if (!db.Roles.AnyAsync().Result)
                {
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                    Task.Run(async () =>
                    {
                        var adminRole = GlobalConstants.AdminRole;
                        var userRole = GlobalConstants.UserRole;

                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminRole
                        });

                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = userRole
                        });

                    }).Wait();
                }

                if (!db.Users.AnyAsync().Result)
                {
                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                    Task.Run(async () =>
                    {
                        var userPassword = "1234";
                        var user = new User
                        {
                            UserName = "Admin",
                            Email = "Admin@admin.com",
                            FirstName = "Admin",
                            LastName = "nimdA"
                        };

                        await userManager.CreateAsync(user, userPassword);
                        await userManager.AddToRoleAsync(user, GlobalConstants.AdminRole);

                    }).Wait();


                }
            }

            return app;
        }
        
    }
}
