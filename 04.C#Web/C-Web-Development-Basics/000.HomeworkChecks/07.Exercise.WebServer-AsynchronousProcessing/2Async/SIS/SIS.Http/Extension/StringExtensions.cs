using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Extension
{
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                //return null;
                throw new ArgumentException($"{nameof(input)} cannot be null");
            }
            return Char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
