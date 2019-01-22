using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Eventures.Web.Middlewares
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomSeedMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDatabaseMiddleware>();
        }      
    }

}
