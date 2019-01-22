using SIS.HTTP.Enums;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode status)
        {
            var statusCode = (int) status;
            var statusMessage = status.ToString().SplitOnCapitalLetters();

            return $"{statusCode} {statusMessage}";
        }
    }
}
