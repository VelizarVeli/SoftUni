namespace SIS.HTTP.Headers
{
    using Common;
    using Contracts;
    using System.Collections.Generic;
    using static Common.GlobalConstants;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            
            this.headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            
            return this.headers.GetValueOrDefault(key, null);
        }

        public override string ToString()
            => string.Join(HttpNewLine, this.headers.Values);
    }
}
