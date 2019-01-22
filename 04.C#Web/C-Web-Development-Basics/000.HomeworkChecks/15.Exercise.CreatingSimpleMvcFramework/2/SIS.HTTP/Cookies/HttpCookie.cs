namespace SIS.HTTP.Cookies
{
    using System;
    using Common;

    public class HttpCookie
    {
        private const int HttpCookieDefaultExpiresDays = 3;

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpiresDays)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));
            
            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpiresDays)
            :this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; }

        public bool HttpOnly { get; set; } = true;

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            var result = $"{this.Key}={this.Value}; Expires={this.Expires:R}";
            if (this.HttpOnly)
            {
                result += "; HttpOnly";
            }

            return result;
        }
    }
}