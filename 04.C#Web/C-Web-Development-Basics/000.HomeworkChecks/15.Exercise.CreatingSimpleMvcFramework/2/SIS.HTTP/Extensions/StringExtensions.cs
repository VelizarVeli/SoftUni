namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string message)
        {
            var firstLetter = message[0].ToString().ToUpper();
            var allOther = message.Substring(1).ToLower();

            return $"{firstLetter}{allOther}";
        }
    }
}