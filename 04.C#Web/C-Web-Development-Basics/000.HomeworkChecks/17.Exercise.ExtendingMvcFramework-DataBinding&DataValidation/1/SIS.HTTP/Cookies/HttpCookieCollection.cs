namespace SIS.HTTP.Cookies
{
    using Common;
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (!this.ContainsCookie(key)) throw new ArgumentException($"{key} cookie not found.");

            return this.cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (KeyValuePair<string, HttpCookie> cookie in this.cookies) yield return cookie.Value;
        }

        public bool HasCookies()
            => this.cookies.Any();

        public override string ToString()
            => string.Join("; ", this.cookies.Values);

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
