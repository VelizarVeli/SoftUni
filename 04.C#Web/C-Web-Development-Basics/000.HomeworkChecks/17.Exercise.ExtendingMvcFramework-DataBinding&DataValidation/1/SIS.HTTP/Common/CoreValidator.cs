namespace SIS.HTTP.Common
{
    using System;

    public static class CoreValidator
    {
        public static void ThrowIfNull(object obj, string name)
        {
            if (obj is null) throw new ArgumentException(name);
        }

        public static void ThrowIfNullOrEmpty(string @string, string name)
        {
            if (string.IsNullOrEmpty(@string)) throw new ArgumentException($"{name} cannot be null or empty.");
        }

        public static void ThrowIfNullOrWhiteSpace(string @string, string name)
        {
            if (string.IsNullOrWhiteSpace(@string)) throw new ArgumentException($"{name} cannot be null or white space.");
        }
    }
}
