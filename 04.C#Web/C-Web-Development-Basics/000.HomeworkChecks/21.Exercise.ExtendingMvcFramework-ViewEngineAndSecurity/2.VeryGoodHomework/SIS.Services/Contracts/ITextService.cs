using System.Globalization;

namespace SIS.Services.Contracts
{
    public interface ITextService
    {
	string ToTitleCase(string text, CultureInfo cultureInfo = null);
    }
}
