using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Services;
using Microsoft.Extensions.Logging;
using Eventures.Web.Filters;
using Eventures.Data;
using Eventures.Web.Middleware.MiddlewareExtentions;
using AutoMapper;
using Eventures.Mapping;
using Eventures.Web.Models.Users;
using Eventures.Services.Models.Orders;
using Eventures.Web.Models.Events;
using Eventures.ServicesViewModels;
using Eventures.Services.Models.Events;

namespace Eventures.Web
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
            AutoMapperConfig.RegisterMappings(
                typeof(LoginViewModel).Assembly,
                typeof(AllOrdersViewModel).Assembly,
                typeof(EventWithTicketsCountViewModel).Assembly,
                typeof(AdminUsersCollectionViewModel).Assembly,
                typeof(AllEventsViewModel).Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<EventuresDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
            })
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<EventuresDbContext>();

            services.AddAutoMapper();

            services.AddScoped<EventsCreateLogActionFilter>();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IAdminService, AdminUserService>();


            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });
            //services.AddLogging();

            services.AddMvc(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IServiceProvider provider,
            ILoggerFactory loggerFactory,
            EventuresDbContext dbContext)
        {
            var loggingFactory = provider.GetService<LoggerFactory>();
            //loggerFactory.AddContext(LogLevel.Error, dbContext);

            if (env.IsDevelopment())
            {
                app.UseSeedDataMiddleware();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseExceptionHandler("/Errors/");
                app.UseHsts();
                app.UseStatusCodePagesWithReExecute("/Errors/Error/{0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
