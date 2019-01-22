using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string inputString)
        {
            return inputString[0].ToString().ToUpper() + inputString.Substring(1).ToLower();
        }
    }
}
