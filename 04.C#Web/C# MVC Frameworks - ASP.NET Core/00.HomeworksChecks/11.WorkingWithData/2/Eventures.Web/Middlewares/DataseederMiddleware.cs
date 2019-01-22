using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Middlewares
{
    public class DataseederMiddleware
    {
        private readonly RequestDelegate _next;

        public DataseederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
                                      EventuresDbContext db,
                                      RoleManager<IdentityRole> roleManager,
                                      UserManager<EventuresUser> userManager)
        {
            //var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            var userRoleExists = roleManager.RoleExistsAsync("User").Result;

            db.Database.Migrate();

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
