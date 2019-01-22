using System;
using AutoMapper;
using Google.App.Core;
using Google.App.Core.Contracts;
using Google.App.Core.Controllers;
using Google.Data;
using Google.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Google.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var service = ConfigureService();

            IEngine engine = new Engine(service);

            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<GoogleContext>(op => op.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddAutoMapper(conf => conf.AddProfile<GoogleProfile>());

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();

            serviceCollection.AddTransient<IManagerController, ManagerController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
