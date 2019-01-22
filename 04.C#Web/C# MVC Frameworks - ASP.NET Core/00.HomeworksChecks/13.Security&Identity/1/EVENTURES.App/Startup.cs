using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EVENTURES.Data;
using EVENTURES.Models;
using EVENTURES.App.Utilities;
using EVENTURES.App.Services.Contracts;
using EVENTURES.App.Services;
using EVENTURES.App.Middleweares.MiddlewareExtensions;
using EVENTURES.App.Logging;
using Microsoft.Extensions.Logging;

namespace EVENTURES.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped(typeof(RoleManager<IdentityRole>));
            services.AddScoped(typeof(IEventServices), typeof(EventServices));
            services.AddScoped(typeof(EventureDbContext));
            services.AddScoped(typeof(IOrderServices), typeof(OrderServices));

            services.AddDbContext<EventureDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<EvUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 3;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<EventureDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Account/AccessDenied";
            });

            services.AddLogging();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider,
            ILoggerFactory loggingRactory, EventureDbContext context)
        {
            //var loggingFactory = serviceProvider.GetService<LoggerFactory>();
            loggingRactory.AddContext(LogLevel.Error, context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            var dbContext = serviceProvider.GetService<EventureDbContext>();
            dbContext.Database.Migrate();

            app.UseSeedDataMiddleware();
            Seeder.Seed(serviceProvider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
