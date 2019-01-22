using System;
using System.Text;

namespace Http.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(string @string)
        {
            if (String.IsNullOrEmpty(@string))
            {
                throw new ArgumentNullException();
            }
            var toLowerStr = @string.ToLower();
            return toLowerStr[0].ToString().ToUpper() + toLowerStr.Substring(1, toLowerStr.Length);

        }
    }
}
