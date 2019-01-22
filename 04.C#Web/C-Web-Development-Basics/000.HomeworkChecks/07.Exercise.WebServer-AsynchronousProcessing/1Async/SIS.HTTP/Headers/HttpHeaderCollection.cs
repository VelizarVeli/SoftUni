namespace SIS.HTTP.Headers
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private const string HeaderNullMessage = "Header cannot be null!";
        private const string HeaderPropertiesNullMessage = "Header properties cannot be null or empty!";
        private const string HeaderIsContainedMessage = "Header is already contained!";
        private const string InvalidKeyMessage = "Key cannot be null or empty!";

        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header == null)
            {
                throw new ArgumentException(HeaderNullMessage);
            }

            if (string.IsNullOrEmpty(header.Key) || string.IsNullOrEmpty(header.Value))
            {
                throw new ArgumentException(HeaderPropertiesNullMessage);
            }

            if (this.ContainsHeader(header.Key))
            {
                throw new InvalidOperationException(HeaderIsContainedMessage);
            }

            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(InvalidKeyMessage);
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(InvalidKeyMessage);
            }

            return this.headers.FirstOrDefault(k => k.Key == key).Value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (HttpHeader header in this.headers.Values)
            {
                sb.AppendLine(header.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
