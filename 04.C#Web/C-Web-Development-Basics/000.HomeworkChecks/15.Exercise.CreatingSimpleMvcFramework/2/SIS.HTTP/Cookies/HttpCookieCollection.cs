namespace SIS.HTTP.Cookies
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (!this.ContainsCookie(cookie.Key))
            {
                this.cookies[cookie.Key] = cookie;
            }
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            return this.cookies[key];
        }

        public bool HasCookies()
        {
            return this.cookies.Any();
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (var cookie in this.cookies)
            {
                yield return cookie.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}