namespace EventuresWebApp.Web.Middlewares.MiddlewareExtensions
{
    using Microsoft.AspNetCore.Builder;

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseSeedDataMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
