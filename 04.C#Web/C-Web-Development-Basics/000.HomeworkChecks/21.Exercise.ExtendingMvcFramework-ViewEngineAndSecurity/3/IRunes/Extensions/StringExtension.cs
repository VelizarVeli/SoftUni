using System.Net;

namespace IRunes.Extensions
{
    public static class StringExtension
    {
        public static string UrlDecode(this string input)
        {
            return WebUtility.UrlDecode(input);
        }
    }
}