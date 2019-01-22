using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace SIS.Framework.Attributes.Properties
{
    public class RegexAttribute : ValidationAttribute
    {
        private readonly string pattern;

        public RegexAttribute(string pattern)
        {
            this.pattern = pattern;
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), this.pattern);
        }
    }
}
