namespace SIS.HTTP.Headers
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header != null && !this.ContainsHeader(header.Key)
                && !string.IsNullOrEmpty(header.Key)
                && !string.IsNullOrEmpty(header.Value))
            {
                this.headers.Add(header.Key, header);
            }
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(Messages.CannotBeNullExceptionMessage, nameof(key));
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(Messages.CannotBeNullExceptionMessage, nameof(key));
            }

            if (!this.ContainsHeader(key))
            {
                return null;
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}