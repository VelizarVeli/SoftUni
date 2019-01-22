namespace SIS.HTTP.Cookies
{
    using Common;
    using System;
    using System.Text;

    public class HttpCookie
    {
        public HttpCookie(string key, string value, int expires = Constants.HttpCookieDefaultExpirationDays, string path = Constants.HttpCookieDefaultPath)
        {
            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Path = path;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = Constants.HttpCookieDefaultExpirationDays)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; }

        public string Path { get; set; }

        public bool HttpOnly { get; } = true;

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-100);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.Key}={this.Value}; Expires={this.Expires:R}");

            if (this.HttpOnly)
            {
                result.Append($"; {Constants.HttpOnly}");
            }

            result.Append($"; Path={this.Path}");

            return result.ToString();
        }
    }
}