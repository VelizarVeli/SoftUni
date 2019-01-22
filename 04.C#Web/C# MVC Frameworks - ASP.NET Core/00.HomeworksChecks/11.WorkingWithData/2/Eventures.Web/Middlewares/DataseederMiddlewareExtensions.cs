using Microsoft.AspNetCore.Builder;


namespace Eventures.Web.Middlewares
{
    public static class DataseederMiddlewareExtensions
    {
        public static IApplicationBuilder UseDataseeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DataseederMiddleware>();
        }
    }
}
