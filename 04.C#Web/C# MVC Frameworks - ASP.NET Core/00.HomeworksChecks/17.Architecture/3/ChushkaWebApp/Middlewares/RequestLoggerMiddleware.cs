namespace EventWebApp.Middlewares
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            var method = httpContext.Request.Method;
            var ipAddress = httpContext.Connection.LocalIpAddress;
            var text = $"Method:{method} with path {path} from {ipAddress}{Environment.NewLine}";
            File.AppendAllText(@"WriteLines.txt", text);
            await this.next(httpContext);
        }
    }
}
