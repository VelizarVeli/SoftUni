namespace SIS.HTTP.Cookies
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (cookie != null && !this.ContainsCookie(cookie.Key))
            //&& !string.IsNullOrEmpty(cookie.Key)
            //&& !string.IsNullOrEmpty(cookie.Value))
            {
                this.cookies[cookie.Key] = cookie;
            }
        }

        public bool ContainsCookie(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"{nameof(key)} cannot be null.");
            }

            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            //if (string.IsNullOrEmpty(key))
            //{
            //    throw new ArgumentException($"{nameof(key)} cannot be null.");
            //}

            if (!this.ContainsCookie(key))
            {
                return null;
            }

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

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}