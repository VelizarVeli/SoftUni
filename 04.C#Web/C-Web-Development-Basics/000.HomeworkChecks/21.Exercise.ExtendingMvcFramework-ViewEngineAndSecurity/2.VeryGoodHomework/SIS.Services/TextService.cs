using System.Globalization;
using SIS.Services.Contracts;

namespace SIS.Services
{
    public class TextService : ITextService
    {
	public string ToTitleCase(string text, CultureInfo cultureInfo = null)
	{
	    if (cultureInfo == null) cultureInfo = CultureInfo.InvariantCulture;
	    TextInfo textInfo = cultureInfo.TextInfo;
	    string textToLowerCase = text.ToLower(cultureInfo);
	    string textToTitleCase = textInfo.ToTitleCase(textToLowerCase);
	    return textToTitleCase;
	}
    }
}
