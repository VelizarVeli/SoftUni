using System;

namespace SIS.HTTP.Cookies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expiresInDays = HttpCookieDefaultExpirationDays)
        {
            this.Key = key;
            this.Value = value;
            this.Expires = DateTime.UtcNow.AddDays(expiresInDays);
            this.IsNew = true;
        }

        public HttpCookie(string key, string value, bool isNew, int expiresInDays = HttpCookieDefaultExpirationDays) 
            : this(key, value, expiresInDays)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; }

        public override string ToString()
            => $"{this.Key}={this.Value}"; //$"{this.Key}={this.Value}; Expires={this.Expires:R}";
    }
}