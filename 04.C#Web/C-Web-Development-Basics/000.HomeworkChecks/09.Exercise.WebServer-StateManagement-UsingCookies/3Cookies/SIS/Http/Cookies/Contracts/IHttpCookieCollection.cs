using System;
using System.Collections.Generic;
using System.Text;

namespace Http.Cookies.Contracts
{
    public interface IHttpCookieCollection
    {
        void Add(HttpCookie cookie);

        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();
    }
}
