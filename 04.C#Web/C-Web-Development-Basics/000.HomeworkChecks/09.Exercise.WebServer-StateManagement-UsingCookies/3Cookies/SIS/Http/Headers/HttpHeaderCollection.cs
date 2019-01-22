using Http.Headers.Contracts;
using System;
using System.Collections.Generic;

namespace Http.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            if (headers.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public HttpHeader GetgHeader(string key)
        {
            if (ContainsHeader(key))
            {
                return headers[key];
            }
            return null;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, headers.Values);
        }
    }
}
