using System;
using System.Collections.Generic;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader httpHeader)
        {
            if (httpHeader == null ||string.IsNullOrWhiteSpace(httpHeader.Key) || 
                string.IsNullOrWhiteSpace(httpHeader.Value))
            {
                throw new ArgumentNullException("httpHeader cannot be null!");
            }

            this.headers.Add(httpHeader.Key, httpHeader);
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} cannot be null!");
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} cannot be null!");
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}