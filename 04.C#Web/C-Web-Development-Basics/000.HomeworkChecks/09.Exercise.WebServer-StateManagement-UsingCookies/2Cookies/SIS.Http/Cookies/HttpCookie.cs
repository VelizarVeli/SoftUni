using System;

namespace SIS.Http.Cookies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationDays)
        {
            this.Key = key;
            this.Value = value;
            this.isNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool inNew, int expires = HttpCookieDefaultExpirationDays)
            : this(key, value, expires)
        {
            this.isNew = isNew;
        }

        public  string Key { get; }

        public  string Value { get; }

        public DateTime Expires { get; }

        public  bool isNew { get; }

        public override string ToString()
            => $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}"; //?

    }
}
