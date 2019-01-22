using System.Collections.Generic;

namespace SIS.HTTP.Cookies.Contracts
{
    public interface IHttpCookieCollection : IEnumerable<IHttpCookie>
    {
	void AddCookie(IHttpCookie cookie);
	bool ContainsCookie(string name);
	IHttpCookie GetCookie(string name);
	void SetCookie(IHttpCookie cookie);
    }
}
