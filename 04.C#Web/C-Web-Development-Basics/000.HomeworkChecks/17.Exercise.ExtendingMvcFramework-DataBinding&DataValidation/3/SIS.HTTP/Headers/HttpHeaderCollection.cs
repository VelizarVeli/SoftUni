using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            return headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            return headers.ContainsKey(key) ? headers[key] : null;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, headers.Values);
        }
    }
}
