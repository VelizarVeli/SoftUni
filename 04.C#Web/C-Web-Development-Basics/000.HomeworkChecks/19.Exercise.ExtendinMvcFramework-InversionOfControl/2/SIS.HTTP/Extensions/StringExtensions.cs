using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (text.Length == 1)
            {
                return text.ToUpper();
            }

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        public static string DeCapitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (text.Length == 1)
            {
                return text.ToLower();
            }

            return char.ToLower(text[0]) + text.Substring(1);
        }
    }
}
