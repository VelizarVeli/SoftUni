using System;
using System.Linq;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Input string cannot be null or empty");
            }

            return str.First().ToString().ToUpper() + str.Substring(1);
        }
    }
}