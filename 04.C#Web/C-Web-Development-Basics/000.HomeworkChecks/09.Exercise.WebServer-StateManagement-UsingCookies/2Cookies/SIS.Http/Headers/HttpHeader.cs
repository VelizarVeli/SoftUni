using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Headers
{
    public  class HttpHeader
    {
        //private string value;
        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
