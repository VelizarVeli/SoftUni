using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.WebApp
{
	using Controllers;
	using Data;
	using EventuresModel;
	using Filter;
	using Microsoft.Extensions.Logging;
	using Middlewares.Extensions;
	using Services.AccountServices;
	using Services.AccountServices.Contracts;
	using Services.EventsServices;
	using Services.EventsServices.Contracts;
	using Utilities;
	using Utilities.Contracts;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
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

			services.AddDbContext<EventuresDbContext>(options =>
				options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<EventuresUser,IdentityRole>(options =>
				{
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
					options.Password.RequiredLength = 3;
					options.Password.RequiredUniqueChars = 1;
				})
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<EventuresDbContext>();

			services.AddTransient<IEventsService, EventsService>();
			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<ICounter, Counter>();
			services.AddTransient<LogEventActionFilter>();

			services.AddLogging(configure => configure.AddConsole()) 
				.AddTransient<LogEventActionFilter>()
				.AddTransient<EventsController>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Account/Login";
				options.LogoutPath = $"/Account/Logout";
				options.AccessDeniedPath = $"/Account/AccessDenied";
			});


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,RoleManager<IdentityRole> roleManager,UserManager<EventuresUser> userManager)
		{
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

			app.UseSeedMiddleware();
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
