namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string @string)
        {
            if (string.IsNullOrEmpty(@string)) return @string;

            if (@string.Length == 1) return @string.ToUpper();

            return char.ToUpper(@string[0]) + @string.Substring(1).ToLower();
        }
    }
}
