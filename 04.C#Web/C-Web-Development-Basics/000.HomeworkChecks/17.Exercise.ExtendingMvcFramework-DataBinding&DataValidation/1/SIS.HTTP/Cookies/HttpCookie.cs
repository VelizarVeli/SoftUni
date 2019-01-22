namespace SIS.HTTP.Cookies
{
    using Common;
    using System;
    using System.Text;

    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;
        private const string HttpCookieDefaultPath = "/";

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationDays, string path = HttpCookieDefaultPath)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
            this.Path = path;
            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationDays, string path = HttpCookieDefaultPath)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; private set; }

        public string Path { get; set; }

        public bool IsNew { get; }

        public bool HttpOnly { get; set; } = true;

        public void Delete()
            => this.Expires = DateTime.UtcNow.AddDays(-1);

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Key}={this.Value}; Expires={this.Expires:R}");

            if (this.HttpOnly) result.Append("; HttpOnly");

            result.Append($"; Path={this.Path}");

            return result.ToString();
        }
    }
}
