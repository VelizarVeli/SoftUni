using System.Text.RegularExpressions;
using SIS.HTTP.Enums;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode code)
        {
            if (code == HttpResponseStatusCode.Ok)
            {
                return "200 OK";
            }

            var result = Regex.Replace(code.ToString(), @"(\p{Lu})", " $1").TrimStart();

            return $"{(int)code} {result}";
        }
    }
}