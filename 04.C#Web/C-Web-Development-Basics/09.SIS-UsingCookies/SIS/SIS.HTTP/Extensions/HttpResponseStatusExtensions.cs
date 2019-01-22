using System;
using System.Net;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpStatusCode statusCode) => $"{(int)statusCode} {statusCode}";
    }
}