﻿using SIS.Http.Headers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Headers
{
    public class HttpHeadersCollection : IHttpHeadersCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeadersCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {

            if (header == null || 
                string.IsNullOrEmpty(header.Key) || 
                string.IsNullOrEmpty(header.Value)||
                ContainsHeader(header.Key))
            {
                throw  new Exception();
            }
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"{nameof(key)} cannot be null");
            }
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"{nameof(key)} cannot be null");
            }
            if (this.ContainsHeader(key))
            {
                return this.headers[key];
            }

            return null;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}
