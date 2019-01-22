using System;

namespace SIS.HTTP.Common
{
    public static class CoreValidator
    {
        public static void ThrowIfNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"Parameter {name} cannot be null.");
            }
        }

        public static void ThrowIfNullOrEmpty(string str, string name)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException($"Parameter {name} cannot be null or empty");
            }
        }
    }
}