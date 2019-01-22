using System;

namespace Http.Cookies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationInDays = 3;

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationInDays)
        {
            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationInDays)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime Expires { get; set; }
        public bool IsNew { get; set; }

        public override string ToString()
            => $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";

    }
}
