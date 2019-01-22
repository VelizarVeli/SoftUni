using System.Net;

namespace Http.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpStatusCode statusCode)
        => $"{(int)statusCode} {statusCode}";
    }
}
