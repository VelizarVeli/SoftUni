using System.Globalization;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);
            return formattedError;
        }
    }
}
