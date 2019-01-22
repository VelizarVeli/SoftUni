using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Web.CustomMiddlewares;
using Microsoft.AspNetCore.Builder;

namespace Eventures.Web.CustomMiddlewareExtensions
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseSeeder>();
        }
    }
}
