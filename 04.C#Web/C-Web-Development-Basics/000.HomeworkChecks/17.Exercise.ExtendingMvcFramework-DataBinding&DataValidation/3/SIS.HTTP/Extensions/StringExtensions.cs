using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    class StringExtensions
    {
        string Capitalize(string inputString)
        {
            return inputString[0].ToString().ToUpper() + inputString.Substring(1).ToLower();
        }
    }
}
