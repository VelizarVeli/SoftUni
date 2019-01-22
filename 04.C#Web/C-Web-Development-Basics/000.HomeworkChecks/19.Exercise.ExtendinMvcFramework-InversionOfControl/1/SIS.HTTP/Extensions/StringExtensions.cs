namespace SIS.HTTP.Extensions
{
    using Common;
    using System;
    using System.Globalization;

    public static class StringExtensions
    {
        public static string Capitalise(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(Messages.CannotBeNullExceptionMessage, nameof(str));
            }

            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}