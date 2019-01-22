using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        private const string CapitalizeErrorMessage = "Cannot capitalize an empty or null string!";

        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(CapitalizeErrorMessage);
            }

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
