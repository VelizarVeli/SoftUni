﻿using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace TorshiaWebApp
{
    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
        }
    }
}
