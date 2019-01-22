using System.Net;
using SIS.Http.Enum;

namespace SIS.Http.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode) =>
             $"{(int) statusCode} {statusCode}";
    }
}
