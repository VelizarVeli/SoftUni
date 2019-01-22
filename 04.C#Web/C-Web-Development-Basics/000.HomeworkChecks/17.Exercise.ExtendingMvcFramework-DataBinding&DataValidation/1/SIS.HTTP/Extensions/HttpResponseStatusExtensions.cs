namespace SIS.HTTP.Extensions
{
    using Enums;
    using System;

    public static class HttpResponseStatusExtensions
    {
        // {0} - Status Code (int)
        private const string NotSupportedStatusCodeExceptionMessage = "Status Code {0} not supported.";

        public static string GetResponseLine(this HttpResponseStatusCode httpResponseStatusCode)
            => GetLineByCode((int)httpResponseStatusCode);

        private static string GetLineByCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200: return "200 OK";
                case 201: return "201 Created";
                case 302: return "302 Found";
                case 303: return "303 See Other";
                case 400: return "400 Bad Request";
                case 401: return "401 Unauthorized";
                case 403: return "403 Forbidden";
                case 404: return "404 Not Found";
                case 500: return "500 Internal Server Error";
            }

            throw new NotSupportedException(string.Format(NotSupportedStatusCodeExceptionMessage, statusCode));
        }
    }
}
