using Http.Cookies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Http.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException();
            }
            if (this.ContainsCookie(cookie.Key))
            {
                throw new Exception();
            }
            cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
            => cookies.ContainsKey(key);

        public HttpCookie GetCookie(string key)
        {
            if (!ContainsCookie(key))
            {
                return null;
            }
            else
            {
                return cookies[key];
            }
        }

        public bool HasCookies()
            => this.cookies.Any();

        public override string ToString()
        {
            return string.Join(";", this.cookies.Values);
        }
    }
}
