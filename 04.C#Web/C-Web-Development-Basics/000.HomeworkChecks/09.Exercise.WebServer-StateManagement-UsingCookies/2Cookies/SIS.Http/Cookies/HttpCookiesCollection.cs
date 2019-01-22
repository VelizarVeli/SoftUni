using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;

namespace SIS.Http.Cookies.Contracts
{
    public class HttpCookiesCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookiesCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie httpCookie)
        {
            if (httpCookie == null /*|| this.ContainsCookie(httpCookie.Key)*/)
            {
                //
                throw  new  ArgumentException();
            }

            this.cookies[httpCookie.Key] =  httpCookie;
        }
        
        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
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

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
