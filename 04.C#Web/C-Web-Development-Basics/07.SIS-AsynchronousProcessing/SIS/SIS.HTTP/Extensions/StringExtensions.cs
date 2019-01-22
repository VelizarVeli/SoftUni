using System;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)} can't be null!");
            }

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
