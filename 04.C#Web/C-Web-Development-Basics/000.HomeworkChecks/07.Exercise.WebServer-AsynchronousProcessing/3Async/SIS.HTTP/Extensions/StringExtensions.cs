using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string SplitOnCapitalLetters(this string input)
        {
            var cleanString = input.ToList();
            for (int i = 1; i < cleanString.Count; i++)
            {
                if (char.IsUpper(cleanString[i]))
                {
                    var temp = new char[cleanString.Count - i];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = cleanString[j + i];
                    }

                    cleanString[i] = ' ';
                    cleanString.Add(' ');

                    var index = 0;
                    for (int j = i + 1; j < cleanString.Count; j++)
                    {
                        cleanString[j] = temp[index];
                        index++;
                    }

                    i++;
                }
            }
            return new string(cleanString.ToArray());
        }

        public static string Capitalize(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            { throw new ArgumentException("Input cannot be null");}

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
