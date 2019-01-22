using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Headers
{
    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
