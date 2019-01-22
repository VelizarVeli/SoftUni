using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Headers.Contracts;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> _headers;

        public HttpHeaderCollection()
        {
            _headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header == null ||
                string.IsNullOrWhiteSpace(header.Key) ||
                string.IsNullOrWhiteSpace(header.Value) ||
                this.ContainsHeader(header.Key))
            {
                throw new ArgumentException("Invalid header!");
            }

            _headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            { throw new ArgumentException($"{nameof(key)} cannot be null!"); }

            return _headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            { throw new ArgumentException($"{nameof(key)} cannot be null!"); }

            return ContainsHeader(key) ? _headers[key] : null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var header in _headers)
            {
                sb.AppendLine(header.Value.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
